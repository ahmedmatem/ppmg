using System;
using System.Linq;

namespace ArrayElementsAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            // четем числа от конзолата и ги записваме в масив
            int[] numbers = Console.ReadLine()
                .Split(' ') // разплита по интервал
                .Select(int.Parse) // превръщаме ги в числа
                .ToArray(); // и ги пращаме към масива

            int sum = 0;

            // Намираме сумата от всички числа в масива ...

            // 2. обхождане на масив
            for (int i = 0; i < numbers.Length; i++)
            {
                sum = sum + numbers[i];
                // sum += numbers[i];
            }

            // Намиране на средно аритметично
            // получената сума разделяме с броя на числата
            // (double)  в израза долу връща резултата в дробно чило
            double average = (double)sum / numbers.Length;

            Console.WriteLine($"Average is {average:F2}");
        }
    }
}
