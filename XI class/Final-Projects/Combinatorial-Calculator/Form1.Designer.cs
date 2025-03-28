﻿namespace Combinatorial_Calculator
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
            textBoxDisplay = new TextBox();
            buttonClear = new Button();
            buttonPower = new Button();
            buttonBinom = new Button();
            buttonBack = new Button();
            buttonComb = new Button();
            buttonNine = new Button();
            buttonEight = new Button();
            buttonSeven = new Button();
            buttonVar = new Button();
            buttonSix = new Button();
            buttonFive = new Button();
            buttonFour = new Button();
            buttonPerm = new Button();
            buttonThree = new Button();
            buttonTwo = new Button();
            buttonOne = new Button();
            buttonEqual = new Button();
            buttonExcl = new Button();
            buttonZero = new Button();
            buttonEmpty = new Button();
            labelResult = new Label();
            SuspendLayout();
            // 
            // textBoxDisplay
            // 
            textBoxDisplay.Font = new Font("Segoe UI", 16F);
            textBoxDisplay.Location = new Point(21, 53);
            textBoxDisplay.Multiline = true;
            textBoxDisplay.Name = "textBoxDisplay";
            textBoxDisplay.Size = new Size(258, 75);
            textBoxDisplay.TabIndex = 0;
            // 
            // buttonClear
            // 
            buttonClear.BackColor = Color.White;
            buttonClear.Location = new Point(21, 134);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(60, 60);
            buttonClear.TabIndex = 1;
            buttonClear.Text = "C";
            buttonClear.UseVisualStyleBackColor = false;
            buttonClear.Click += buttonClear_Click;
            // 
            // buttonPower
            // 
            buttonPower.BackColor = Color.White;
            buttonPower.BackgroundImage = (Image)resources.GetObject("buttonPower.BackgroundImage");
            buttonPower.BackgroundImageLayout = ImageLayout.Center;
            buttonPower.Location = new Point(87, 134);
            buttonPower.Name = "buttonPower";
            buttonPower.Size = new Size(60, 60);
            buttonPower.TabIndex = 2;
            buttonPower.UseVisualStyleBackColor = false;
            buttonPower.Click += buttonPower_Click;
            // 
            // buttonBinom
            // 
            buttonBinom.BackColor = Color.White;
            buttonBinom.BackgroundImage = (Image)resources.GetObject("buttonBinom.BackgroundImage");
            buttonBinom.BackgroundImageLayout = ImageLayout.Center;
            buttonBinom.Location = new Point(153, 134);
            buttonBinom.Name = "buttonBinom";
            buttonBinom.Size = new Size(60, 60);
            buttonBinom.TabIndex = 3;
            buttonBinom.UseVisualStyleBackColor = false;
            // 
            // buttonBack
            // 
            buttonBack.BackColor = Color.White;
            buttonBack.BackgroundImage = (Image)resources.GetObject("buttonBack.BackgroundImage");
            buttonBack.BackgroundImageLayout = ImageLayout.Center;
            buttonBack.Location = new Point(219, 134);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(60, 60);
            buttonBack.TabIndex = 4;
            buttonBack.UseVisualStyleBackColor = false;
            // 
            // buttonComb
            // 
            buttonComb.BackColor = Color.White;
            buttonComb.BackgroundImage = (Image)resources.GetObject("buttonComb.BackgroundImage");
            buttonComb.BackgroundImageLayout = ImageLayout.Center;
            buttonComb.Location = new Point(219, 200);
            buttonComb.Name = "buttonComb";
            buttonComb.Size = new Size(60, 60);
            buttonComb.TabIndex = 8;
            buttonComb.UseVisualStyleBackColor = false;
            buttonComb.Click += buttonComb_Click;
            // 
            // buttonNine
            // 
            buttonNine.BackColor = Color.White;
            buttonNine.Location = new Point(153, 200);
            buttonNine.Name = "buttonNine";
            buttonNine.Size = new Size(60, 60);
            buttonNine.TabIndex = 7;
            buttonNine.Tag = "Digit";
            buttonNine.Text = "9";
            buttonNine.UseVisualStyleBackColor = false;
            // 
            // buttonEight
            // 
            buttonEight.BackColor = Color.White;
            buttonEight.Location = new Point(87, 200);
            buttonEight.Name = "buttonEight";
            buttonEight.Size = new Size(60, 60);
            buttonEight.TabIndex = 6;
            buttonEight.Tag = "Digit";
            buttonEight.Text = "8";
            buttonEight.UseVisualStyleBackColor = false;
            // 
            // buttonSeven
            // 
            buttonSeven.BackColor = Color.White;
            buttonSeven.Location = new Point(21, 200);
            buttonSeven.Name = "buttonSeven";
            buttonSeven.Size = new Size(60, 60);
            buttonSeven.TabIndex = 5;
            buttonSeven.Tag = "Digit";
            buttonSeven.Text = "7";
            buttonSeven.UseVisualStyleBackColor = false;
            // 
            // buttonVar
            // 
            buttonVar.BackColor = Color.White;
            buttonVar.BackgroundImage = (Image)resources.GetObject("buttonVar.BackgroundImage");
            buttonVar.BackgroundImageLayout = ImageLayout.Center;
            buttonVar.Location = new Point(219, 266);
            buttonVar.Name = "buttonVar";
            buttonVar.Size = new Size(60, 60);
            buttonVar.TabIndex = 12;
            buttonVar.UseVisualStyleBackColor = false;
            // 
            // buttonSix
            // 
            buttonSix.BackColor = Color.White;
            buttonSix.Location = new Point(153, 266);
            buttonSix.Name = "buttonSix";
            buttonSix.Size = new Size(60, 60);
            buttonSix.TabIndex = 11;
            buttonSix.Tag = "Digit";
            buttonSix.Text = "6";
            buttonSix.UseVisualStyleBackColor = false;
            // 
            // buttonFive
            // 
            buttonFive.BackColor = Color.White;
            buttonFive.Location = new Point(87, 266);
            buttonFive.Name = "buttonFive";
            buttonFive.Size = new Size(60, 60);
            buttonFive.TabIndex = 10;
            buttonFive.Tag = "Digit";
            buttonFive.Text = "5";
            buttonFive.UseVisualStyleBackColor = false;
            // 
            // buttonFour
            // 
            buttonFour.BackColor = Color.White;
            buttonFour.Location = new Point(21, 266);
            buttonFour.Name = "buttonFour";
            buttonFour.Size = new Size(60, 60);
            buttonFour.TabIndex = 9;
            buttonFour.Tag = "Digit";
            buttonFour.Text = "4";
            buttonFour.UseVisualStyleBackColor = false;
            // 
            // buttonPerm
            // 
            buttonPerm.BackColor = Color.White;
            buttonPerm.BackgroundImage = (Image)resources.GetObject("buttonPerm.BackgroundImage");
            buttonPerm.BackgroundImageLayout = ImageLayout.Center;
            buttonPerm.Location = new Point(219, 332);
            buttonPerm.Name = "buttonPerm";
            buttonPerm.Size = new Size(60, 60);
            buttonPerm.TabIndex = 16;
            buttonPerm.UseVisualStyleBackColor = false;
            // 
            // buttonThree
            // 
            buttonThree.BackColor = Color.White;
            buttonThree.Location = new Point(153, 332);
            buttonThree.Name = "buttonThree";
            buttonThree.Size = new Size(60, 60);
            buttonThree.TabIndex = 15;
            buttonThree.Tag = "Digit";
            buttonThree.Text = "3";
            buttonThree.UseVisualStyleBackColor = false;
            buttonThree.Click += buttonThree_Click;
            // 
            // buttonTwo
            // 
            buttonTwo.BackColor = Color.White;
            buttonTwo.Location = new Point(87, 332);
            buttonTwo.Name = "buttonTwo";
            buttonTwo.Size = new Size(60, 60);
            buttonTwo.TabIndex = 14;
            buttonTwo.Tag = "Digit";
            buttonTwo.Text = "2";
            buttonTwo.UseVisualStyleBackColor = false;
            // 
            // buttonOne
            // 
            buttonOne.BackColor = Color.White;
            buttonOne.Location = new Point(21, 332);
            buttonOne.Name = "buttonOne";
            buttonOne.Size = new Size(60, 60);
            buttonOne.TabIndex = 13;
            buttonOne.Tag = "Digit";
            buttonOne.Text = "1";
            buttonOne.UseVisualStyleBackColor = false;
            // 
            // buttonEqual
            // 
            buttonEqual.BackColor = Color.White;
            buttonEqual.Location = new Point(219, 398);
            buttonEqual.Name = "buttonEqual";
            buttonEqual.Size = new Size(60, 60);
            buttonEqual.TabIndex = 20;
            buttonEqual.Text = "=";
            buttonEqual.UseVisualStyleBackColor = false;
            buttonEqual.Click += buttonEqual_Click;
            // 
            // buttonExcl
            // 
            buttonExcl.BackColor = Color.White;
            buttonExcl.Location = new Point(153, 398);
            buttonExcl.Name = "buttonExcl";
            buttonExcl.Size = new Size(60, 60);
            buttonExcl.TabIndex = 19;
            buttonExcl.Text = "!";
            buttonExcl.UseVisualStyleBackColor = false;
            buttonExcl.Click += buttonExcl_Click;
            // 
            // buttonZero
            // 
            buttonZero.BackColor = Color.White;
            buttonZero.Location = new Point(87, 398);
            buttonZero.Name = "buttonZero";
            buttonZero.Size = new Size(60, 60);
            buttonZero.TabIndex = 18;
            buttonZero.Tag = "Digit";
            buttonZero.Text = "0";
            buttonZero.UseVisualStyleBackColor = false;
            // 
            // buttonEmpty
            // 
            buttonEmpty.BackColor = Color.White;
            buttonEmpty.Enabled = false;
            buttonEmpty.Location = new Point(21, 398);
            buttonEmpty.Name = "buttonEmpty";
            buttonEmpty.Size = new Size(60, 60);
            buttonEmpty.TabIndex = 17;
            buttonEmpty.UseVisualStyleBackColor = false;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(21, 18);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(0, 20);
            labelResult.TabIndex = 21;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 479);
            Controls.Add(labelResult);
            Controls.Add(buttonEqual);
            Controls.Add(buttonExcl);
            Controls.Add(buttonZero);
            Controls.Add(buttonEmpty);
            Controls.Add(buttonPerm);
            Controls.Add(buttonThree);
            Controls.Add(buttonTwo);
            Controls.Add(buttonOne);
            Controls.Add(buttonVar);
            Controls.Add(buttonSix);
            Controls.Add(buttonFive);
            Controls.Add(buttonFour);
            Controls.Add(buttonComb);
            Controls.Add(buttonNine);
            Controls.Add(buttonEight);
            Controls.Add(buttonSeven);
            Controls.Add(buttonBack);
            Controls.Add(buttonBinom);
            Controls.Add(buttonPower);
            Controls.Add(buttonClear);
            Controls.Add(textBoxDisplay);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxDisplay;
        private Button buttonClear;
        private Button buttonPower;
        private Button buttonBinom;
        private Button buttonBack;
        private Button buttonComb;
        private Button buttonNine;
        private Button buttonEight;
        private Button buttonSeven;
        private Button buttonVar;
        private Button buttonSix;
        private Button buttonFive;
        private Button buttonFour;
        private Button buttonPerm;
        private Button buttonThree;
        private Button buttonTwo;
        private Button buttonOne;
        private Button buttonEqual;
        private Button buttonExcl;
        private Button buttonZero;
        private Button buttonEmpty;
        private Label labelResult;
    }
}
