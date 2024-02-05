using System;
using System.Linq;

namespace Linear_Equation
{
    class Program
    {
        static void Main(string[] args)
        {
            // b.x = c
            // 16x = 32
            // 4x = 13
            // Примерен вход: 4 28

            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            double b = numbers[0];
            double c = numbers[1];

            if(b != 0)
            {
                Console.WriteLine($"{c / b}");
            }
            else
            {
                if(c == 0)
                {
                    Console.WriteLine("Each x is solution.");
                }
                else
                {
                    Console.WriteLine("No solution.");
                }
            }
        }
    }
}
