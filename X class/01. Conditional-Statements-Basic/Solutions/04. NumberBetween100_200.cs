using System;

namespace NmmberBetween100_200
{
    class NumberBetween100_200
    {
        static void Main(string[] args)
        {
            // прочитаме цяло число от конзолата
            int number = int.Parse(Console.ReadLine());

            // проверяваме в кой интервал е числото спрямо 100 и 200
            if(number < 100)
            {
                Console.WriteLine("Less than 100");
            }
            else if(number <= 200)
            {
                Console.WriteLine("Between 100 and 200");
            }
            else
            {
                Console.WriteLine("Bigger than 200");
            }
        }
    }
}
