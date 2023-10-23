using System;

namespace EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            const int ZeroSymbolCode = (int)'0';

            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            bool hasSuchANumber = false;

            for (int number = start; number <= end; number++)
            {
                // зануляваме двете суми
                int evenSum = 0; 
                int oddSum = 0; 
                string numberAsString = number.ToString();
                for (int i = 0; i < numberAsString.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        // четна позиция
                        //evenSum += int.Parse(numberAsString[i].ToString());
                        evenSum += (int)numberAsString[i] - ZeroSymbolCode;
                    }
                    else
                    {
                        // нечетна позиция
                        oddSum += (int)numberAsString[i] - ZeroSymbolCode;
                    }
                }
                if(evenSum == oddSum)
                {
                    hasSuchANumber = true;
                    Console.Write(number + " ");
                }
            }

            if(!hasSuchANumber)
            {
                Console.WriteLine("No output");
            }
        }
    }
}
