using System;

namespace EvenOddNumber
{
    class EvenOddNumber
    {
        static void Main(string[] args)
        {
            // прочитаме ЦЯЛО число от конзолата
            int number = int.Parse(Console.ReadLine());

            // делим с остатък на 2 за да проверим дали е четно/нечетно
            if(number % 2 == 0) // ако се дели на 2 (с остаък 0)
            {
                // отпечатваме четно
                Console.WriteLine("even");
            }
            else
            {
                // отпечатваме нечетно
                Console.WriteLine("odd");
            }
        }
    }
}
