using System;

namespace MultyplyingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int[] numbers = new int[N];

            for (int i = 0; i < N; i++)
            {
                numbers[i] = i * 5;
            }

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
