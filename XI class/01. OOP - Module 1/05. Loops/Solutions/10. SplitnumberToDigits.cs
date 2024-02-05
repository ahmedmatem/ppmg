using System;

namespace SplitNumberToDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            // read a number: 1234
            int number = int.Parse(Console.ReadLine());

            int lastDigit = 0;
            do
            {
                // get last digit: 4 at begining
                lastDigit = number % 10;
                // get the number wiyhout last digit: 123 at begining
                number /= 10; // same as - number = number / 10;
                Console.Write(lastDigit + " ");
            } while (number != 0);
        }
    }
}
