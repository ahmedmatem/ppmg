namespace Travel_Map
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            comboBoxFrom = new ComboBox();
            buttonCalculate = new Button();
            labelDistance = new Label();
            labelPath = new Label();
            label3 = new Label();
            comboBoxTo = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(619, 417);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 494);
            label1.Name = "label1";
            label1.Size = new Size(26, 20);
            label1.TabIndex = 1;
            label1.Text = "От";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(269, 494);
            label2.Name = "label2";
            label2.Size = new Size(28, 20);
            label2.TabIndex = 2;
            label2.Text = "До";
            // 
            // comboBoxFrom
            // 
            comboBoxFrom.FormattingEnabled = true;
            comboBoxFrom.Items.AddRange(new object[] { "София", "Пловдив", "Варна", "Бургас", "Русе", "Стара Загора", "Благоевград", "Велико Търново", "Плевен", "Разград" });
            comboBoxFrom.Location = new Point(49, 486);
            comboBoxFrom.Name = "comboBoxFrom";
            comboBoxFrom.Size = new Size(193, 28);
            comboBoxFrom.TabIndex = 3;
            // 
            // buttonCalculate
            // 
            buttonCalculate.Location = new Point(519, 485);
            buttonCalculate.Name = "buttonCalculate";
            buttonCalculate.Size = new Size(112, 29);
            buttonCalculate.TabIndex = 5;
            buttonCalculate.Text = "Изчисли";
            buttonCalculate.UseVisualStyleBackColor = true;
            buttonCalculate.Click += buttonCalculate_Click;
            // 
            // labelDistance
            // 
            labelDistance.AutoSize = true;
            labelDistance.Location = new Point(17, 533);
            labelDistance.Name = "labelDistance";
            labelDistance.Size = new Size(0, 20);
            labelDistance.TabIndex = 7;
            // 
            // labelPath
            // 
            labelPath.AutoSize = true;
            labelPath.Location = new Point(17, 567);
            labelPath.Name = "labelPath";
            labelPath.Size = new Size(0, 20);
            labelPath.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 450);
            label3.Name = "label3";
            label3.Size = new Size(132, 20);
            label3.TabIndex = 9;
            label3.Text = "Разстояние и път:";
            // 
            // comboBoxTo
            // 
            comboBoxTo.FormattingEnabled = true;
            comboBoxTo.Items.AddRange(new object[] { "София", "Пловдив", "Варна", "Бургас", "Русе", "Стара Загора", "Благоевград", "Велико Търново", "Плевен", "Разград" });
            comboBoxTo.Location = new Point(303, 486);
            comboBoxTo.Name = "comboBoxTo";
            comboBoxTo.Size = new Size(193, 28);
            comboBoxTo.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(659, 607);
            Controls.Add(comboBoxTo);
            Controls.Add(label3);
            Controls.Add(labelPath);
            Controls.Add(labelDistance);
            Controls.Add(buttonCalculate);
            Controls.Add(comboBoxFrom);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private ComboBox comboBoxFrom;
        private Button buttonCalculate;
        private Label labelDistance;
        private Label labelPath;
        private Label label3;
        private ComboBox comboBoxTo;
    }
}
