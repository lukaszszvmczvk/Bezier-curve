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
            groupBox3 = new GroupBox();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            checkBox1 = new CheckBox();
            groupBox2 = new GroupBox();
            radioButton5 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            groupBox1 = new GroupBox();
            imagePictureBox = new PictureBox();
            button2 = new Button();
            button1 = new Button();
            visiblePoylineCheckBox = new CheckBox();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            panel1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
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
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(visiblePoylineCheckBox);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(1415, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(164, 847);
            panel1.TabIndex = 1;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(radioButton4);
            groupBox3.Controls.Add(radioButton3);
            groupBox3.Controls.Add(checkBox1);
            groupBox3.Location = new Point(7, 331);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(148, 114);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Animation";
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(6, 56);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(140, 24);
            radioButton4.TabIndex = 7;
            radioButton4.TabStop = true;
            radioButton4.Text = "Moving on curve";
            radioButton4.UseVisualStyleBackColor = true;
            radioButton4.CheckedChanged += radioButton4_CheckedChanged;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(6, 84);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(87, 24);
            radioButton3.TabIndex = 6;
            radioButton3.TabStop = true;
            radioButton3.Text = "Rotation";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(6, 26);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(96, 24);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "Animaton";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radioButton5);
            groupBox2.Controls.Add(radioButton2);
            groupBox2.Controls.Add(radioButton1);
            groupBox2.Location = new Point(7, 205);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(154, 120);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Rotation";
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(11, 86);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(145, 24);
            radioButton5.TabIndex = 2;
            radioButton5.TabStop = true;
            radioButton5.Text = "Graphics function";
            radioButton5.UseVisualStyleBackColor = true;
            radioButton5.CheckedChanged += radioButton5_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(11, 56);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(117, 24);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "With filtering";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(11, 26);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(68, 24);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Naive";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
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
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
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
        private GroupBox groupBox2;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private GroupBox groupBox3;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton5;
    }
}