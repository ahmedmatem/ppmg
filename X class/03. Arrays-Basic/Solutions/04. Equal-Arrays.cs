using System;
using System.Linq;

namespace EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] arr2 = Console.ReadLine()
               .Split(' ')
               .Select(int.Parse)
               .ToArray();

            bool isEqual = true;

            for (int i = 0; i < arr1.Length; i++)
            {
                if(arr1[i] != arr2[i])
                {
                    isEqual = false;
                    break; // излизаме от тялото на цикъла
                }
            }

            if(isEqual)
            {
                // isEqual == true
                Console.WriteLine("Yes");
            }
            else
            {
                // isEqual == false
                Console.WriteLine("No");
            }
        }
    }
}
