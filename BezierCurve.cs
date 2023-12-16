using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace lab3
{
    public class BezierCurve
    {
        private PictureBox pictureBox;
        private int r = 10;
        private float interval = 0.0001f;
        private float animationInterval = 0.01f;
        int? selectedPointId = null;
        private int N
        {
            get { return ControlPoints.Count - 1; }
        }
        private List<Point> CurvePoints { get; set; }
        private List<Vector2> ControlPoints { get; set; }
        public bool VisiblePolyline { get; set; }
        public Bitmap? Img { get; set; }
        public float pos { get; set; }
        public bool UseNaiveRotation { get; set; }
        public bool RotateAnimation { get; set; }

        public BezierCurve(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            VisiblePolyline = true;
            pictureBox.MouseDown += canvasMouseDown;
            pictureBox.MouseUp += PictureBox_MouseUp;
            pictureBox.MouseMove += PictureBox_MouseMove;
            UseNaiveRotation = true;
            Img = null;
            InitializePoints();
            Draw();
        }

        public void InitializePoints()
        {
            ControlPoints = new List<Vector2>();
            CurvePoints = new List<Point>();
        }
        public void Draw()
        {
            Bitmap bitmap = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);

            Pen pen = new Pen(Brushes.LightBlue, 2);
            for(int i=0; i<ControlPoints.Count; ++i)
            {
                if(i != ControlPoints.Count-1 && VisiblePolyline)
                {
                    var p1 = new PointF(ControlPoints[i].X, ControlPoints[i].Y);
                    var p2 = new PointF(ControlPoints[i+1].X, ControlPoints[i+1].Y);
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.DrawLine(pen, p1,p2);
                    }
                }
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.FillEllipse(Brushes.Red, ControlPoints[i].X - r, ControlPoints[i].Y - r, 2 * r, 2 * r);
                }
            }

            foreach (var pt in CurvePoints)
            {
                bitmap.SetPixel(pt.X, pt.Y, Color.Black);
            }

            var angle = BezierTangentAngle(pos);
            var p = GetPointOnCurve(pos);
            if (ControlPoints.Count > 2 && Img != null)
            {
                if (!RotateAnimation)
                {
                    Bitmap rotatedBitmap = RotateBitmap(angle);
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.DrawImage(rotatedBitmap, new Point((int)p.X - rotatedBitmap.Width / 2, (int)p.Y - rotatedBitmap.Height / 2));
                    }
                }
                else
                {
                    Bitmap rotatedBitmap = Img;
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.DrawImage(rotatedBitmap, new Point((int)p.X - rotatedBitmap.Width / 2, (int)p.Y - rotatedBitmap.Height / 2));
                    }
                }

            }

            pictureBox.Image.Dispose();
            pictureBox.Image = bitmap;
            pictureBox.Refresh();
        }
        private void ComputeBezierCurve()
        {
            CurvePoints.Clear();
            for (float t = 0.0f; t <= 1.0f; t += interval)
            {
                var p = GetPointOnCurve(t);
                CurvePoints.Add(new Point((int)p.X, (int)p.Y));
            }
        }
        private Vector2 GetPointOnCurve(float t)
        {
            var p = new Vector2();
            for (int i = 0; i < ControlPoints.Count; ++i)
            {
                var n = Bernstein(N, i, t) * ControlPoints[i];
                p += n;
            }
            return p;
        }
        private float Bernstein(int n, int i, float t)
        {
            return GetBinCoeff(n, i) * MathF.Pow(t, i) * MathF.Pow(1 - t, n - i);
        }
        public long GetBinCoeff(long n, long k)
        {
            // Taken from:  http://blog.plover.com/math/choose.html
            long r = 1;
            long d;
            if (k > n) return 0;
            for (d = 1; d <= k; d++)
            {
                r *= n--;
                r /= d;
            }
            return r;
        }
        private float BezierTangentAngle(float t)
        {
            var p = new Vector2();
            for (int i = 0; i < ControlPoints.Count-1; ++i)
            {
                var n = Bernstein(N-1, i, t) * (ControlPoints[i + 1] - ControlPoints[i]);
                p += n;
            }
            p *= N;
            var angle = (float)(Math.Atan2(p.Y, p.X) * (180 / Math.PI));
            return angle;
        }
        private Bitmap RotateBitmap(float angle)
        {
            if(UseNaiveRotation)
            {
                return NaiveRotate(angle);
            }
            else
            {
                Bitmap rotatedBitmap = new Bitmap(Img.Width, Img.Height);

                rotatedBitmap.SetResolution(Img.HorizontalResolution, Img.VerticalResolution);

                using (Graphics g = Graphics.FromImage(rotatedBitmap))
                {
                    g.TranslateTransform((float)Img.Width / 2, (float)Img.Height / 2);
                    g.RotateTransform(angle);
                    g.TranslateTransform(-(float)Img.Width / 2, -(float)Img.Height / 2);

                    g.DrawImage(Img, new Point(0, 0));
                }
                return rotatedBitmap;
            }
        }
        private Bitmap NaiveRotate(float degree)
        {
            double rads = degree * Math.PI / 180.0;

            int width = Img.Width;
            int height = Img.Height;

            Bitmap rotatedBitmap = new Bitmap(width, height);

            var centerX = width / 2;
            var centerY = height / 2;

            for (int i = 0; i < rotatedBitmap.Height; i++)
            {
                for (int j = 0; j < rotatedBitmap.Width; j++)
                {
                    var x = (i - centerX) * Math.Cos(rads) + (j - centerY) * Math.Sin(rads);
                    var y = -(i - centerX) * Math.Sin(rads) + (j - centerY) * Math.Cos(rads);

                    var sx = (int)Math.Round(x) + centerX;
                    var sy = (int)Math.Round(y) + centerY;

                    if (sx >= 0 && sy >= 0 && sx < Img.Height && sy < Img.Width)
                    {
                        rotatedBitmap.SetPixel(i, j, Img.GetPixel(sx, sy));
                    }
                }
            }

            return rotatedBitmap;
        }

        // Utility functions
        public bool SelectPoint(MouseEventArgs e)
        {
            for (int i = 0; i < ControlPoints.Count; ++i)
            {
                if (IsPointClicked(e, ControlPoints[i]))
                {
                    selectedPointId = i;
                    return true;
                }
            }
            return false;
        }
        private bool IsPointClicked(MouseEventArgs e, Vector2 p)
        {
            int X = e.X;
            int Y = e.Y;
            return Math.Abs(X - p.X) <= r && Math.Abs(Y - p.Y) <= r;
        }
        private void canvasMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var isPointSelected = SelectPoint(e);
                if(!isPointSelected)
                {
                    ControlPoints.Add(new Vector2(e.X, e.Y));
                }
                ComputeBezierCurve();
                Draw();
            }
        }
        private void PictureBox_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectedPointId = null;
            }
        }
        private void PictureBox_MouseMove(object? sender, MouseEventArgs e)
        {
            if (selectedPointId != null)
            {
                ControlPoints[selectedPointId.Value] = new Vector2(e.X, e.Y);
                ComputeBezierCurve();
                Draw();
            }

        }
        public void UpdatePos()
        {
            pos += animationInterval;
            if(pos >= 1)
            {
                pos = 1;
                animationInterval = -animationInterval;
            }

            if(pos <= 0)
            {
                pos = 0;
                animationInterval = -animationInterval;
            }
        }
        public void Clear()
        {
            CurvePoints.Clear();
            ControlPoints.Clear();
            pos = 0;
            Img = null;
        }
    }
}
