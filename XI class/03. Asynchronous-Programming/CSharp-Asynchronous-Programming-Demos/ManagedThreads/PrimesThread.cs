namespace ManagedThreads
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    class PrimesThread
    {
        static void Main()
        {
            Thread primesThread = new Thread(() => PrintPrimesInRange(10, 100000));
            primesThread.Start();

            Console.WriteLine("What should I do?");
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "stop")
                {
                    primesThread.Abort();
                }
                else if (command == "exit")
                {
                    break;
                }
            }

            primesThread.Join();
        }

        static void PrintPrimesInRange(int rangeFirst, int rangeLast)
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

            Console.WriteLine(string.Join(", ", primes));
        }
    }
}
