using System.Numerics;

namespace lab3
{
    public class BezierCurve
    {
        private PictureBox pictureBox;
        private int r = 10;
        private float interval = 0.0001f;
        private float animationInterval = 0.01f;
        private int rotateAngle = 0;
        private Bitmap rotatedImage;
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
                    rotatedImage = RotateBitmap(angle);
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.DrawImage(rotatedImage, new Point((int)p.X - rotatedImage.Width / 2, (int)p.Y - rotatedImage.Height / 2));
                    }
                }
                else
                {
                    rotatedImage = RotateBitmap(rotateAngle);
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.DrawImage(rotatedImage, new Point((int)p.X - rotatedImage.Width / 2, (int)p.Y - rotatedImage.Height / 2));
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
                return RotateImageShear(angle);
            }
        }
        private Bitmap NaiveRotate(float angle)
        {
            Bitmap dst = new Bitmap(Img.Width, Img.Height);

            float radians = (float)(angle * Math.PI / 180);

            float cosTheta = (float)Math.Cos(radians);
            float sinTheta = (float)Math.Sin(radians);

            var centerX = dst.Width / 2;
            var centerY = dst.Height / 2;
            for (int dx = 0; dx < dst.Width; dx++)
            {
                for (int dy = 0; dy < dst.Height; dy++)
                {
                    var x = dx - centerX;
                    var y = dy - centerY;

                    int sx = (int)(cosTheta * x + sinTheta * y) + centerX;
                    int sy = (int)(-sinTheta * x + cosTheta * y) + centerY;

                    if (sx >= 0 && sx < Img.Width && sy >= 0 && sy < Img.Height)
                    {
                        dst.SetPixel(dx, dy, Img.GetPixel(sx, sy));
                    }
                }
            }

            return dst;
        }
        private Bitmap RotateImageShear(float degree)
        {
            double rads = degree * Math.PI / 180.0;
            int width = Img.Width;
            int height = Img.Height;

            var centerX = width / 2;
            var centerY = height / 2;

            Bitmap rotatedBitmap = new Bitmap(width, height);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int y = height - 1 - i - centerY;
                    int x = width - 1 - j - centerX;

                    (int new_y, int new_x) = Shear(rads, x, y);

                    new_y = centerY - new_y;
                    new_x = centerX - new_x;

                    if (new_y >= 0 && new_y < height && new_x >= 0 && new_x < width)
                    {
                        rotatedBitmap.SetPixel(new_x, new_y, Img.GetPixel(j, i));
                    }
                }
            }
            return rotatedBitmap;
        }
        private (int, int) Shear(double rads, int x, int y)
        {
            var tan = Math.Tan(rads / 2);
            double new_x = x - Math.Tan(rads / 2) * y;
            double new_y = y;
            new_y = Math.Sin(rads)*new_x + new_y;
            new_x = new_x - Math.Tan(rads / 2) * new_y;
            return ((int)new_y, (int)new_x);
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
        public void UpdateAngle()
        {
            rotateAngle++;
            if (rotateAngle == 360)
                rotateAngle = 0;
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
