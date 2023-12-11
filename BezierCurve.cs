using System;
using System.Collections.Generic;
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
        int? selectedPointId = null;
        private int N
        {
            get { return ControlPoints.Count - 1; }
        }
        private List<Point> CurvePoints { get; set; }
        private List<Vector2> ControlPoints { get; set; }
        public bool VisiblePolyline { get; set; }

        public BezierCurve(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            VisiblePolyline = true;
            pictureBox.MouseDown += canvasMouseDown;
            pictureBox.MouseUp += PictureBox_MouseUp;
            pictureBox.MouseMove += PictureBox_MouseMove;
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

            foreach(var pt in CurvePoints)
            {
                bitmap.SetPixel(pt.X, pt.Y, Color.Black);
            }
            pictureBox.Image.Dispose();
            pictureBox.Image = bitmap;
            pictureBox.Refresh();
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
        private void ComputeBezierCurve()
        {
            CurvePoints.Clear();

            float interval = 0.0001f;
            for (float t = 0.0f; t <= 1.0f + interval - 0.0001f; t += interval)
            {
                Vector2 p = new Vector2();
                for (int i = 0; i < ControlPoints.Count; ++i)
                {
                    Vector2 bn = Bernstein(i, t) * ControlPoints[i];
                    p += bn;
                }
                CurvePoints.Add(new Point((int)p.X, (int)p.Y));
            }
        }
        private float Bernstein(int i, float t)
        {
            return GetBinCoeff(N, i) * MathF.Pow(t, i) * MathF.Pow(1 - t, N - i);
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
        public void Clear()
        {
            CurvePoints.Clear();
            ControlPoints.Clear();
        }
    }
}
