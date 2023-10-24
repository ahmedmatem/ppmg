using System;
using System.Linq;

namespace ArrayElementsSum
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. прочитаме числа разделени с интервал от конзолата
            int[] numbers = Console.ReadLine()
                .Split(' ') // разплита по интервал
                .Select(int.Parse) // превръщаме ги в числа
                .ToArray(); // и ги пращаме към масива

            int sum = 0;

            // 2. обхождане на масив
            for (int i = 0; i < numbers.Length; i++)
            {
                // добавяме поредния посетен елемент от масива към sum
                sum = sum + numbers[i]; // sum += numbers[i];
            }

            // 3. отпечатване на сумата
            Console.WriteLine($"The sum is {sum}");
        }
    }
}
