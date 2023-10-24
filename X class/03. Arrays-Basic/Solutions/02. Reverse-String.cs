using System;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();
            string[] reversedArr = new string[arr.Length];

            int j = 0;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                reversedArr[j] = arr[i];
                j++;
            }

            Console.WriteLine(string.Join(' ', reversedArr));
        }
    }
}
