using System.Text;

namespace BigIntegerSum
{
/*
923847238931983192462832102
934572893617836459843471846187346 
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] firstNumber = Console.ReadLine().ToCharArray();
            char[] secondNumber = Console.ReadLine().ToCharArray();

            char[] longNumber, shortNumber;
            if (firstNumber.Length >= secondNumber.Length)
            {
                longNumber = firstNumber;
                shortNumber = secondNumber;
            }
            else
            {
                longNumber = secondNumber;
                shortNumber = firstNumber;
            }

            Array.Reverse(longNumber);
            Array.Reverse(shortNumber);

            string sum = string.Empty;

            int inMind = 0;
            for (int i = 0; i < shortNumber.Length; i++)
            {
                int currentSum = int.Parse(longNumber[i].ToString()) + int.Parse(shortNumber[i].ToString()) + inMind;
                inMind = currentSum / 10;
                sum += currentSum % 10;
            }

            for (int i = shortNumber.Length; i < longNumber.Length; i++)
            {
                int currentSum = int.Parse(longNumber[i].ToString()) + inMind;
                inMind = currentSum / 10;
                sum += currentSum % 10;
            }

            if (inMind != 0)
            {
                sum += inMind;
            }

            char[] result = sum.ToCharArray();
            Array.Reverse(result);
            Console.WriteLine(result);
        }
    }
}
