namespace Click_Maniac
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
            button1 = new Button();
            label1 = new Label();
            textBoxTimer = new TextBox();
            panelGameBoard = new Panel();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 15F);
            button1.Location = new Point(12, 25);
            button1.Name = "button1";
            button1.Size = new Size(500, 53);
            button1.TabIndex = 0;
            button1.Text = "Начало на играта";
            button1.UseVisualStyleBackColor = true;
            button1.Click += OnStart;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(255, 101);
            label1.Name = "label1";
            label1.Size = new Size(126, 20);
            label1.TabIndex = 1;
            label1.Text = "Оставащо време";
            // 
            // textBoxTimer
            // 
            textBoxTimer.Enabled = false;
            textBoxTimer.Location = new Point(387, 94);
            textBoxTimer.Name = "textBoxTimer";
            textBoxTimer.Size = new Size(125, 27);
            textBoxTimer.TabIndex = 2;
            // 
            // panelGameBoard
            // 
            panelGameBoard.BackColor = Color.Khaki;
            panelGameBoard.Location = new Point(12, 127);
            panelGameBoard.Name = "panelGameBoard";
            panelGameBoard.Size = new Size(500, 500);
            panelGameBoard.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleGreen;
            ClientSize = new Size(526, 642);
            Controls.Add(panelGameBoard);
            Controls.Add(textBoxTimer);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox textBoxTimer;
        private Panel panelGameBoard;
    }
}
