using System;
using System.Diagnostics;

namespace SumOfCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            int n = int.Parse(Console.ReadLine());
            int tripleNumbers = 0;

            // търсим тройки от числа (x1, x2, x3) такива, че x1 + x2 + x3 = n

            int allCombinations = 0;

            watch.Start();
            for (int x1 = 0; x1 <= n; x1++)
            {
                for (int x2 = 0; x2 <= n - x1; x2++)
                {
                    for (int x3 = 0; x3 <= n - (x1 + x2) ; x3++)
                    {
                        allCombinations++;
                        if (x1 + x2 + x3 == n)
                        {
                            tripleNumbers++;
                        }
                    }
                }
            }

            var timeElapsed = watch.ElapsedMilliseconds;

            Console.WriteLine($"Algorithm complete in {timeElapsed} milliseconds.");

            Console.WriteLine(tripleNumbers);
            Console.WriteLine($"All combinations are {allCombinations}");

        }
    }
}
