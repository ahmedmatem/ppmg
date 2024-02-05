using System;

namespace HelpDimo
{
    class Program
    {
        static void Main(string[] args)
        {
            int target = int.Parse(Console.ReadLine());
            int startTarget = target - 30;

            int currentTarget = startTarget;
            int currentAttempt = 3;

            int allAttempts = 0;

            do
            {
                do
                {
                    allAttempts++;
                    var jumpInCm = int.Parse(Console.ReadLine());
                    if(jumpInCm > currentTarget)
                    {
                        // успешен скок
                        currentAttempt = 3; // нулираме междинните опити
                        // увеличаваме следващата междинна цел с 5см
                        currentTarget += 5;
                        break;
                    }
                    else
                    {
                        // неуспешен скок
                        currentAttempt--;
                    }
                } while (currentAttempt > 0);
                if(currentAttempt == 0)
                {
                    // използвали сме и трите опита за междинна цел
                    Console.WriteLine($"{currentTarget}cm was too hard for Dimo to reach. He made {allAttempts} tries.");
                }

            } while (currentTarget <= target);

            if(currentAttempt > 0)
            {
                Console.WriteLine($"Dimo did it, he reached his goal with {currentTarget - 5}cm. He made {allAttempts} tries.");
            }
        }
    }
}
