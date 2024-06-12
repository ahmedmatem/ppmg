using System.Numerics;

#nullable disable

namespace Combinatorial_Calculator
{
    public partial class Form1 : Form
    {
        private string firstOperand = string.Empty;
        private string secondOperand = string.Empty;
        private bool isFirstOperand = true;
        private OperationType operation = OperationType.None;

        public Form1()
        {
            InitializeComponent();
            foreach (Control control in Controls)
            {
                if (control is Button && control?.Tag?.ToString() == "Digit")
                {
                    control.Click += OnDigitClick;
                }
            }
        }

        private void OnDigitClick(object sender, EventArgs e)
        {
            var clickedDigitButton = sender as Button;
            AppendDigit(clickedDigitButton!.Text);
        }

        private void AppendDigit(string digit)
        {
            if (isFirstOperand)
            {
                firstOperand += digit;
            }
            else
            {
                secondOperand += digit;
            }
            // Append digit to display
            textBoxDisplay.Text += digit;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearDisplay();
        }

        private void ClearDisplay()
        {
            textBoxDisplay.Text = string.Empty;
            firstOperand = string.Empty;
            secondOperand = string.Empty;
            operation = OperationType.None;
            isFirstOperand = true;
            labelResult.Text = string.Empty;
        }

        private void buttonPower_Click(object sender, EventArgs e)
        {
            operation = OperationType.Power;
            isFirstOperand = false;
            textBoxDisplay.Text += " ^ ";
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            string result = string.Empty;
            switch (operation)
            {
                case OperationType.Power:
                    result = Calculator.Power(firstOperand, secondOperand);
                    break;
                case OperationType.Factoriel:
                    result = Calculator.Factoriel(firstOperand);
                    break;
                default:
                    break;
            }

            labelResult.Text = textBoxDisplay.Text;
            textBoxDisplay.Clear();
            textBoxDisplay.Text = result.ToString();
        }

        private void buttonThree_Click(object sender, EventArgs e)
        {

        }

        private void buttonComb_Click(object sender, EventArgs e)
        {
            operation = OperationType.Combination;
            isFirstOperand = false;
            textBoxDisplay.Text += " <comb> ";
        }

        private void buttonExcl_Click(object sender, EventArgs e)
        {
            operation = OperationType.Factoriel;
            textBoxDisplay.Text += "!";
            buttonEqual_Click(sender, e);
        }
    }
}
