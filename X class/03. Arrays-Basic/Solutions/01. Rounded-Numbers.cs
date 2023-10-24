using System;
using System.Linq;

namespace RoundedNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                double roundedNumber = Math.Round(numbers[i], MidpointRounding.AwayFromZero);
                Console.WriteLine($"{numbers[i]} => {roundedNumber}");
            }

            //int length = numbers.Length;
            //double[] roundedNumbers = new double[length];

            //for (int i = 0; i < length; i++)
            //{
            //    roundedNumbers[i] = Math.Round(numbers[i], MidpointRounding.AwayFromZero);
            //}

            //for (int i = 0; i < length; i++)
            //{
            //    Console.WriteLine($"{numbers[i]} => {roundedNumbers[i]}");
            //}
        }
    }
}
