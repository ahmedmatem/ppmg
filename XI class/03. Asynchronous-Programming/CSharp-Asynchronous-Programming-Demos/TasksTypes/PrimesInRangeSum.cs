namespace TasksTypes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    class PrimesInRangeSum
    {
        static void Main()
        {
            var primesSumTask = PrimesInRangeSumAsync(0, 1000);
           
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "show")
                {
                    Console.WriteLine(primesSumTask.Result);
                }
            }
        }

        static Task<long> PrimesInRangeSumAsync(int rangeFirst, int rangeLast)
        {
            return Task.Run<long>(() =>
            {
                var primes = PrimesInRange(rangeFirst, rangeLast);

                return primes.Sum();
            });
        }

        static List<int> PrimesInRange(int rangeFirst, int rangeLast)
        {
            List<int> primes = new List<int>();

            for (int number = rangeFirst; number < rangeLast; number++)
            {
                bool isPrime = true;
                for (int divider = 2; divider < number; divider++)
                {
                    if (number % divider == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes.Add(number);
                }
            }

            return primes;
        }
    }
}
