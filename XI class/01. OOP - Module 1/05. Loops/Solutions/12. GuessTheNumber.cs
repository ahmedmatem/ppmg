using System;

/**
 * Problem: Guess the Number Game
 * 
 * Write a C# program for a "Guess the Number" game where the computer selects
 * a random number between a specified range, and the player has to guess the number. 
 * Use a do-while loop to repeatedly prompt the player for guesses 
 * until they guess correctly.
 **/

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());

            // Generate random number in given range
            var random = new Random();
            int randomNumber = random.Next(range);

            int guessNumber;
            do
            {
                guessNumber = int.Parse(Console.ReadLine());
                if(guessNumber == randomNumber)
                {
                    // познали сме числото
                    Console.WriteLine("You did it.");
                    //break;
                }
                else
                {
                    if(guessNumber < randomNumber)
                    {
                        // предположеното от нас число е по-малко
                        Console.WriteLine("Good job. Try again with bigger number.");
                    }
                    else
                    {
                        // предположеното от нас число е по-голямо
                        Console.WriteLine("Good job. Try again with lower number.");
                    }
                }
            } while (guessNumber != randomNumber);
        }
    }
}
