using System;

namespace BiggerNumber
{
    class BiggerNumber
    {
        static void Main(string[] args)
        {
            // прочитаме две ЦЕЛИ числа от конзолата
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            // сравняваме числата и отпечатваме по-голямото
            if(firstNumber > secondNumber)
            {
                // първото число е по-голямо
                Console.WriteLine(firstNumber);
            }
            else
            {
                // второто число е по-голямо / или са равни
                Console.WriteLine(secondNumber);
            }
        }
    }
}
