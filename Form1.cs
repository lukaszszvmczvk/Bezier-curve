namespace lab3
{
    public partial class Form1 : Form
    {
        BezierCurve bezierCurve;
        public Form1()
        {
            InitializeComponent();
            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            bezierCurve = new BezierCurve(pictureBox);
            visiblePoylineCheckBox.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bezierCurve.Clear();
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
                bezierCurve.Img = new Bitmap(bmp, 150, 150);
                imagePictureBox.Image = new Bitmap(bmp, imagePictureBox.Width, imagePictureBox.Height);
                bezierCurve.Draw();
            }
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