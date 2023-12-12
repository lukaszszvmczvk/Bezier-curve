namespace lab3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox = new DoubleBufferedPictureBox();
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            imagePictureBox = new PictureBox();
            button2 = new Button();
            button1 = new Button();
            visiblePoylineCheckBox = new CheckBox();
            checkBox1 = new CheckBox();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imagePictureBox).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 89.28571F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.7142849F));
            tableLayoutPanel1.Controls.Add(pictureBox, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1582, 853);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox
            // 
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Location = new Point(3, 3);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(1406, 847);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(visiblePoylineCheckBox);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(1415, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(164, 847);
            panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(imagePictureBox);
            groupBox1.Controls.Add(button2);
            groupBox1.Location = new Point(3, 74);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(158, 125);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Image";
            // 
            // imagePictureBox
            // 
            imagePictureBox.BackColor = SystemColors.AppWorkspace;
            imagePictureBox.Location = new Point(27, 22);
            imagePictureBox.Name = "imagePictureBox";
            imagePictureBox.Size = new Size(105, 62);
            imagePictureBox.TabIndex = 1;
            imagePictureBox.TabStop = false;
            // 
            // button2
            // 
            button2.Location = new Point(0, 90);
            button2.Name = "button2";
            button2.Size = new Size(158, 29);
            button2.TabIndex = 0;
            button2.Text = "Select image";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(0, 39);
            button1.Name = "button1";
            button1.Size = new Size(161, 29);
            button1.TabIndex = 3;
            button1.Text = "Clear ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // visiblePoylineCheckBox
            // 
            visiblePoylineCheckBox.AutoSize = true;
            visiblePoylineCheckBox.Location = new Point(3, 9);
            visiblePoylineCheckBox.Name = "visiblePoylineCheckBox";
            visiblePoylineCheckBox.Size = new Size(132, 24);
            visiblePoylineCheckBox.TabIndex = 2;
            visiblePoylineCheckBox.Text = "Visible polyline";
            visiblePoylineCheckBox.UseVisualStyleBackColor = true;
            visiblePoylineCheckBox.CheckedChanged += visiblePoylineCheckBox_CheckedChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(3, 205);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(96, 24);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "Animaton";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1582, 853);
            Controls.Add(tableLayoutPanel1);
            MaximumSize = new Size(1600, 900);
            MinimumSize = new Size(1600, 900);
            Name = "Form1";
            Text = "Bezier image move";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)imagePictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DoubleBufferedPictureBox pictureBox;
        private Panel panel1;
        private CheckBox visiblePoylineCheckBox;
        private Button button1;
        private GroupBox groupBox1;
        private Button button2;
        private PictureBox imagePictureBox;
        private CheckBox checkBox1;
    }
}