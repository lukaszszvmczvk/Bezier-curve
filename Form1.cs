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
    }

    public class DoubleBufferedPictureBox : PictureBox
    {
        public DoubleBufferedPictureBox()
        {
            DoubleBuffered = true;
        }
    }
}