using System;
using System.Linq;

namespace CheckElementInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            // прочитаме числа от един ред разделени с интервал
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            // прочитаме число, което ще проверим дали се среща в масива
            int checkedNumber = int.Parse(Console.ReadLine());

            bool isExists = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == checkedNumber)
                {
                    isExists = true;
                    Console.WriteLine($"{checkedNumber} exists at position {i + 1}");
                    break; // напускаме тялото на цикъла
                }
            }

            //foreach (int number in numbers)
            //{
            //    if (number == checkedNumber)
            //    {
            //        isExists = true;
            //        Console.WriteLine($"{checkedNumber} exists.");
            //        break;
            //    }
            //}

            // проверка, дали сме срещнали числото в масива
            if (!isExists)
            {
                Console.WriteLine("Not exists!");
            }

        }
    }
}
