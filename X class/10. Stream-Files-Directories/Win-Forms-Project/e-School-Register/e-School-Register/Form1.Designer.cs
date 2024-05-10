namespace e_School_Register
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
            buttonCancel = new Button();
            buttonSave = new Button();
            textBoxFullName = new TextBox();
            comboBoxClass = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panelClass = new Panel();
            listBoxStudents = new ListBox();
            comboBoxStudentClass = new ComboBox();
            label5 = new Label();
            panelInput.SuspendLayout();
            panelClass.SuspendLayout();
            SuspendLayout();
            // 
            // panelInput
            // 
            panelInput.Controls.Add(richTextBoxStudentMarks);
            panelInput.Controls.Add(buttonCancel);
            panelInput.Controls.Add(buttonSave);
            panelInput.Controls.Add(textBoxFullName);
            panelInput.Controls.Add(comboBoxClass);
            panelInput.Controls.Add(label4);
            panelInput.Controls.Add(label3);
            panelInput.Controls.Add(label2);
            panelInput.Controls.Add(label1);
            panelInput.Location = new Point(526, 12);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(490, 468);
            panelInput.TabIndex = 0;
            // 
            // richTextBoxStudentMarks
            // 
            richTextBoxStudentMarks.Location = new Point(64, 137);
            richTextBoxStudentMarks.Name = "richTextBoxStudentMarks";
            richTextBoxStudentMarks.Size = new Size(362, 246);
            richTextBoxStudentMarks.TabIndex = 9;
            richTextBoxStudentMarks.Text = "";
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(332, 407);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 29);
            buttonCancel.TabIndex = 8;
            buttonCancel.Text = "Отказ";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(232, 407);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 7;
            buttonSave.Text = "Запази";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += OnButtonSaveClick;
            // 
            // textBoxFullName
            // 
            textBoxFullName.Location = new Point(64, 44);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(245, 27);
            textBoxFullName.TabIndex = 5;
            // 
            // comboBoxClass
            // 
            comboBoxClass.FormattingEnabled = true;
            comboBoxClass.Items.AddRange(new object[] { "10а", "10б", "10в", "10г" });
            comboBoxClass.Location = new Point(328, 44);
            comboBoxClass.Name = "comboBoxClass";
            comboBoxClass.Size = new Size(98, 28);
            comboBoxClass.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            label4.ForeColor = Color.DimGray;
            label4.Location = new Point(64, 115);
            label4.Name = "label4";
            label4.Size = new Size(188, 19);
            label4.TabIndex = 3;
            label4.Text = "(Пример: Математика - 6)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(64, 95);
            label3.Name = "label3";
            label3.Size = new Size(357, 20);
            label3.TabIndex = 2;
            label3.Text = "Въведете предмети с оценки (на отделни редове)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(328, 21);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 1;
            label2.Text = "Клас";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(64, 21);
            label1.Name = "label1";
            label1.Size = new Size(112, 20);
            label1.TabIndex = 0;
            label1.Text = "Име на ученик";
            // 
            // panelClass
            // 
            panelClass.Controls.Add(listBoxStudents);
            panelClass.Controls.Add(comboBoxStudentClass);
            panelClass.Controls.Add(label5);
            panelClass.Location = new Point(12, 12);
            panelClass.Name = "panelClass";
            panelClass.Size = new Size(490, 468);
            panelClass.TabIndex = 1;
            // 
            // listBoxStudents
            // 
            listBoxStudents.FormattingEnabled = true;
            listBoxStudents.ItemHeight = 20;
            listBoxStudents.Location = new Point(24, 62);
            listBoxStudents.Name = "listBoxStudents";
            listBoxStudents.Size = new Size(444, 384);
            listBoxStudents.TabIndex = 2;
            listBoxStudents.SelectedIndexChanged += listBoxStudents_SelectedIndexChanged;
            listBoxStudents.DoubleClick += StudentsListDoubleClick;
            // 
            // comboBoxStudentClass
            // 
            comboBoxStudentClass.FormattingEnabled = true;
            comboBoxStudentClass.Items.AddRange(new object[] { "10а", "10б", "10в", "10г" });
            comboBoxStudentClass.Location = new Point(71, 18);
            comboBoxStudentClass.Name = "comboBoxStudentClass";
            comboBoxStudentClass.Size = new Size(99, 28);
            comboBoxStudentClass.TabIndex = 1;
            comboBoxStudentClass.Text = "10а";
            comboBoxStudentClass.SelectedIndexChanged += OnClassChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 21);
            label5.Name = "label5";
            label5.Size = new Size(41, 20);
            label5.TabIndex = 0;
            label5.Text = "Клас";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1041, 495);
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
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox comboBoxClass;
        private TextBox textBoxFullName;
        private Button buttonCancel;
        private Button buttonSave;
        private Panel panelClass;
        private ListBox listBoxStudents;
        private ComboBox comboBoxStudentClass;
        private Label label5;
        private RichTextBox richTextBoxStudentMarks;
    }
}
