﻿namespace DayOfWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number in [1..7]");

            int day = int.Parse(Console.ReadLine());

            switch (day)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                case 7:
                    Console.WriteLine("Sunday");
                    break;
                default:
                    Console.WriteLine("The number must be in [1..7]");
                    break;
            }
        }
    }
}
