namespace e_School_Register_2
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
            panelInput = new Panel();
            richTextBoxStudentMarks = new RichTextBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            comboBoxClass = new ComboBox();
            textBoxFullName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panelClass = new Panel();
            listBoxStudents = new ListBox();
            comboBoxStudentsClass = new ComboBox();
            label5 = new Label();
            panelInput.SuspendLayout();
            panelClass.SuspendLayout();
            SuspendLayout();
            // 
            // panelInput
            // 
            panelInput.Controls.Add(richTextBoxStudentMarks);
            panelInput.Controls.Add(buttonSave);
            panelInput.Controls.Add(buttonCancel);
            panelInput.Controls.Add(comboBoxClass);
            panelInput.Controls.Add(textBoxFullName);
            panelInput.Controls.Add(label4);
            panelInput.Controls.Add(label3);
            panelInput.Controls.Add(label2);
            panelInput.Controls.Add(label1);
            panelInput.Location = new Point(479, 12);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(440, 363);
            panelInput.TabIndex = 0;
            // 
            // richTextBoxStudentMarks
            // 
            richTextBoxStudentMarks.Location = new Point(23, 129);
            richTextBoxStudentMarks.Name = "richTextBoxStudentMarks";
            richTextBoxStudentMarks.Size = new Size(386, 175);
            richTextBoxStudentMarks.TabIndex = 9;
            richTextBoxStudentMarks.Text = "";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(215, 310);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 8;
            buttonSave.Text = "Запази";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += OnButtonSaveClick;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(315, 310);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 29);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Отказ";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // comboBoxClass
            // 
            comboBoxClass.FormattingEnabled = true;
            comboBoxClass.Items.AddRange(new object[] { "10а", "10б", "10в", "10г" });
            comboBoxClass.Location = new Point(337, 38);
            comboBoxClass.Name = "comboBoxClass";
            comboBoxClass.Size = new Size(72, 28);
            comboBoxClass.TabIndex = 5;
            // 
            // textBoxFullName
            // 
            textBoxFullName.Location = new Point(23, 39);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(290, 27);
            textBoxFullName.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(23, 107);
            label4.Name = "label4";
            label4.Size = new Size(188, 19);
            label4.TabIndex = 3;
            label4.Text = "(Пример: Математика - 6)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 87);
            label3.Name = "label3";
            label3.Size = new Size(357, 20);
            label3.TabIndex = 2;
            label3.Text = "Въведете предмети с оценки (на отделни редове)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(337, 16);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 1;
            label2.Text = "Клас";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 16);
            label1.Name = "label1";
            label1.Size = new Size(112, 20);
            label1.TabIndex = 0;
            label1.Text = "Име на ученик";
            label1.Click += label1_Click;
            // 
            // panelClass
            // 
            panelClass.Controls.Add(listBoxStudents);
            panelClass.Controls.Add(comboBoxStudentsClass);
            panelClass.Controls.Add(label5);
            panelClass.Location = new Point(12, 12);
            panelClass.Name = "panelClass";
            panelClass.Size = new Size(440, 363);
            panelClass.TabIndex = 1;
            // 
            // listBoxStudents
            // 
            listBoxStudents.FormattingEnabled = true;
            listBoxStudents.ItemHeight = 20;
            listBoxStudents.Location = new Point(16, 37);
            listBoxStudents.Name = "listBoxStudents";
            listBoxStudents.Size = new Size(404, 304);
            listBoxStudents.TabIndex = 2;
            // 
            // comboBoxStudentsClass
            // 
            comboBoxStudentsClass.FormattingEnabled = true;
            comboBoxStudentsClass.Location = new Point(63, 3);
            comboBoxStudentsClass.Name = "comboBoxStudentsClass";
            comboBoxStudentsClass.Size = new Size(97, 28);
            comboBoxStudentsClass.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 9);
            label5.Name = "label5";
            label5.Size = new Size(41, 20);
            label5.TabIndex = 0;
            label5.Text = "Клас";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1330, 715);
            Controls.Add(panelClass);
            Controls.Add(panelInput);
            Name = "Form1";
            Text = "Form1";
            panelInput.ResumeLayout(false);
            panelInput.PerformLayout();
            panelClass.ResumeLayout(false);
            panelClass.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelInput;
        private Button buttonSave;
        private Button buttonCancel;
        private ComboBox comboBoxClass;
        private TextBox textBoxFullName;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panelClass;
        private ListBox listBoxStudents;
        private ComboBox comboBoxStudentsClass;
        private Label label5;
        private RichTextBox richTextBoxStudentMarks;
    }
}
