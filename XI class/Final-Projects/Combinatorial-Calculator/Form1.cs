using System.Numerics;

namespace Combinatorial_Calculator
{
    public partial class Form1 : Form
    {
        private string firstOperand = string.Empty;
        private string secondOperand = string.Empty;
        private bool isFirstOperand = true;
        private string operation = string.Empty;

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
            operation = string.Empty;
            isFirstOperand = true;
        }

        private void buttonPower_Click(object sender, EventArgs e)
        {
            operation = "power";
            isFirstOperand = false;
            textBoxDisplay.Text += " ^ ";
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Clear();
            string result = string.Empty;
            switch(operation)
            {
                case "power":
                    BigInteger firstBigOperand = BigInteger.Parse(firstOperand);
                    BigInteger secondBigOperand = BigInteger.Parse(secondOperand);
                    BigInteger bigResult = BigInteger.One;
                    for (int i = 1; i <= secondBigOperand; i++)
                    {
                        bigResult *= firstBigOperand;
                    }
                    result = bigResult.ToString();
                    break;
                default:
                    break;
            }

            textBoxDisplay.Text = result.ToString();
        }
    }
}
