using System;

namespace Darts
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName = Console.ReadLine();
            int playerPoints = 301;

            int successfulShots = 0; // успешни опити
            int unseccessfulShots = 0; // неуспешни опити
            string command;
            while((command = Console.ReadLine()) != "Retire")
            {
                string field = command; // Single, Double or Triple
                int points = int.Parse(Console.ReadLine()); // точки
                int totalPoints = 0;
                switch(field)
                {
                    case "Single":
                        totalPoints = points;
                        break;
                    case "Double":
                        totalPoints = points * 2;
                        break;
                    case "Triple":
                        totalPoints = points * 3;
                        break;
                    default:
                        break;
                }

                if(playerPoints - totalPoints < 0)
                {
                    // неуспешен опит
                    unseccessfulShots++;
                }
                else
                {
                    // успешен опит
                    successfulShots++;
                    playerPoints -= totalPoints;
                }

                if(playerPoints == 0)
                {
                    Console.WriteLine($"{playerName} won the leg with {successfulShots} shots.");
                    break;
                }
            }

            if(command == "Retire")
            {
                Console.WriteLine($"{playerName} retired after {unseccessfulShots} unsuccessful shots.");
            }
        }
    }
}
