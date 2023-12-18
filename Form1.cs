using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
        BezierCurve bezierCurve;
        System.Windows.Forms.Timer timer;
        bool generateImage = false;
        public Form1()
        {
            InitializeComponent();
            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            bezierCurve = new BezierCurve(pictureBox);
            visiblePoylineCheckBox.Checked = true;
            timer = new System.Windows.Forms.Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 1;
            radioButton1.Checked = true;
            radioButton4.Checked = true;
            trackBar1.Minimum = 0;
            trackBar1.Maximum = 360;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                bezierCurve.UpdatePos();
            }
            else
            {
                bezierCurve.UpdateAngle();
            }
            bezierCurve.Draw();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bezierCurve.Clear();
            imagePictureBox.Image = null;
            checkBox1.Checked = false;
            timer.Stop();
            bezierCurve.Draw();
        }

        private void visiblePoylineCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bezierCurve.VisiblePolyline = visiblePoylineCheckBox.Checked;
            bezierCurve.Draw();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Pliki obrazów (*.jpg, *.jpeg, *.png, *.gif)|*.jpg; *.jpeg; *.png; *.gif";
            openFileDialog1.Title = "Wybierz obraz";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                var bmp = new Bitmap(filePath);
                var tmpBmp = new Bitmap(bmp, 150, 150);
                int size = (int)(150 * 1.5);
                var bitmap = new Bitmap(size, size);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    var x = (int)(size - 150) / 2;
                    g.DrawImage(tmpBmp, new Point(x, x));
                }
                bezierCurve.Img = bitmap;
                imagePictureBox.Image = new Bitmap(bmp, imagePictureBox.Width, imagePictureBox.Height);
                bezierCurve.Draw();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                timer.Start();
            }
            else
            {
                timer.Stop();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                bezierCurve.rotation = Rotation.naive;
                bezierCurve.Draw();
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                bezierCurve.RotateAnimation = false;
            }
            else
            {
                bezierCurve.RotateAnimation = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                bezierCurve.rotation = Rotation.filter;
                bezierCurve.Draw();
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                bezierCurve.rotation = Rotation.graphics;
                bezierCurve.Draw();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Pliki XML (*.xml)|*.xml";
                saveFileDialog.Title = "Wybierz miejsce i nazwê pliku do zapisu";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    bezierCurve.Save(filePath);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Pliki XML (*.xml)|*.xml";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;

                imagePictureBox.Image = null;
                bezierCurve.Clear();

                bezierCurve.Load(filePath);
                bezierCurve.Draw();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if(generateImage)
                CreateImage();
        }
        private void CreateImage()
        {
            double hue = trackBar1.Value;
            var size = 150;
            Bitmap bitmap = new Bitmap(size, size);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    double sat = (double)i / (double)size;
                    double light = (double)j / (double)size;
                    var color = HSLToRGB(hue, sat, light);
                    bitmap.SetPixel(i, j, color);
                }
            }

            int size2 = (int)(150 * 1.5);
            var bmp = new Bitmap(size2, size2);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                var x = (int)(size2 - 150) / 2;
                g.DrawImage(bitmap, new Point(x, x));
            }
            bezierCurve.Img = bmp;
            imagePictureBox.Image = new Bitmap(bitmap, imagePictureBox.Width, imagePictureBox.Height);
            bezierCurve.Draw();
        }

        private Color HSLToRGB(double hue, double saturation, double lightness)
        {
            double c = (1 - Math.Abs(2 * lightness - 1)) * saturation;
            double x = c * (1 - Math.Abs((hue / 60) % 2 - 1));
            double m = lightness - c / 2;

            double red = 0, green = 0, blue = 0;

            if (0 <= hue && hue < 60)
            {
                red = c;
                green = x;
            }
            else if (60 <= hue && hue < 120)
            {
                red = x;
                green = c;
            }
            else if (120 <= hue && hue < 180)
            {
                green = c;
                blue = x;
            }
            else if (180 <= hue && hue < 240)
            {
                green = x;
                blue = c;
            }
            else if (240 <= hue && hue < 300)
            {
                red = x;
                blue = c;
            }
            else if (300 <= hue && hue < 360)
            {
                red = c;
                blue = x;
            }

            int redValue = Convert.ToInt32((red + m) * 255);
            int greenValue = Convert.ToInt32((green + m) * 255);
            int blueValue = Convert.ToInt32((blue + m) * 255);

            return Color.FromArgb(redValue, greenValue, blueValue);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            generateImage = checkBox2.Checked;
            trackBar1_Scroll(sender, e);
        }
    }

    public class DoubleBufferedPictureBox : PictureBox
    {
        public DoubleBufferedPictureBox()
        {
            DoubleBuffered = true;
        }
    }
}