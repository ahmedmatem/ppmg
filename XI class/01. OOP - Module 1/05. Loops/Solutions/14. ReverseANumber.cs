using System;

/**
 * Problem: Reverse a Number
 * 
 * Write a C# program that takes an integer as input and reverses its digits.
 * Use a while loop to accomplish this task.
 **/

namespace ReverseANumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // прочитаме число за обръщане
            int number = int.Parse(Console.ReadLine());

            int lastDigit = 0;
            int reversedNumber = 0;
            do
            {
                // прочитане на последната цифра
                lastDigit = number % 10;
                // числото без последната цифра
                number = number / 10; // number /= 10

                // генерираме обърнато число от всяка последно прочетена цифра
                reversedNumber = reversedNumber * 10 + lastDigit;
            } while (number != 0);

            Console.WriteLine(reversedNumber);
        }
    }
}
