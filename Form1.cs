namespace lab3
{
    public partial class Form1 : Form
    {
        BezierCurve bezierCurve;
        public Form1()
        {
            InitializeComponent();
            bezierCurve = new BezierCurve(pictureBox);
            visiblePoylineCheckBox.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bezierCurve.ControlPoints.Clear();
            bezierCurve.Draw();
        }

        private void visiblePoylineCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bezierCurve.VisiblePolyline = visiblePoylineCheckBox.Checked;
            bezierCurve.Draw();
        }
    }
}