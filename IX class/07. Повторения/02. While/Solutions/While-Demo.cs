using System.Diagnostics.Tracing;

namespace While_Demo_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int oddCounter = 0; // брояч на Нечетни числа
            int evenCounter = 0;// брояч на Четни числа

            int evenSum = 0; // сума на четните числа
            int oddSum = 0; // сума на Нечетните числа

            int number = int.Parse(Console.ReadLine());

            while(number != 0)
            {
                if(number % 2 == 0) // четно
                {
                    evenCounter++;
                    evenSum += number; // добавяме number към четната сума
                }
                else // нечетно
                {
                    oddCounter++;
                    oddSum += number; // добавяме number към Нечетната сума
                }

                // прочитаме следващото число
                number = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"Even numbers: {evenCounter}");
            Console.WriteLine("Odd numbers: " + oddCounter);

            Console.WriteLine("Even sum: " + evenSum);
            Console.WriteLine("Odd sum: " + oddSum);

            Console.WriteLine("Even average: " + (1.0 * evenSum / evenCounter));
            Console.WriteLine("Odd average: " + (1.0 * oddSum / oddCounter));
        }
    }
}
