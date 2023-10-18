using System;

/*

1
10
5

23
24
20


 */

namespace MagicNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int combinationNumber = 0;
            bool magicCoupleFound = false;

            for (int firstNumber = start; firstNumber <= end; firstNumber++)
            {
                int secondNumber;
                for (secondNumber = start; secondNumber <= end; secondNumber++)
                {
                    // (firstNunmber, secondNumber)
                    combinationNumber++;
                    if(firstNumber + secondNumber == magicNumber)
                    {
                        magicCoupleFound = true;
                        break;
                    }
                }

                if(magicCoupleFound)
                {
                    Console.WriteLine($"Combination N:{combinationNumber} ({firstNumber} + {secondNumber} = {magicNumber})");
                    break;
                }
            }

            if(!magicCoupleFound)
            {
                Console.WriteLine($"{combinationNumber} combinations - neither equals {magicNumber}");
            }

        }
    }
}
