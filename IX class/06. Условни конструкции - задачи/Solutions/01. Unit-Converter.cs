using System;

namespace UnitConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double amount = double.Parse(Console.ReadLine()); // 12
            string from = Console.ReadLine(); // mm
            string to = Console.ReadLine();   // ft

            // превръщаме числото в метри
            if(from == "mm")
            {
                // mm --> m
                //amount = amount / 1000;
                amount /= 1000;
            }
            else if(from == "cm")
            {
                // cm --> m
                amount /= 100;
            }
            else if(from == "m")
            {
                // m --> m
                // числото е в метри и няма нужда да се преобразува
            }
            else if(from == "mi")
            {
                // mi --> m
                amount /= 0.000621371192;
            }
            else if(from == "in")
            {
                // in --> m
                amount /= 39.3700787;
            }
            else if(from == "km")
            {
                // km --> m
                amount /= 0.001;
            }
            else if(from == "ft")
            {
                // ft --> m
                amount /= 3.2808399;
            }
            else if(from == "yd")
            {
                // yd --> m
                amount /= 1.0936133;
            }
            else
            {
                Console.WriteLine("Invalid input from.");
            }

            // превръщаме метрите към изходната мерна единица
            switch(to)
            {
                case "m":
                    // m --> m
                    break;
                case "mm":
                    // m --> mm
                    amount *= 1000; // amount = amount * 1000;
                    break;
                case "cm":
                    // m --> cm
                    amount *= 100;
                    break;
                case "mi":
                    // m --> mi
                    amount *= 0.000621371192;
                    break;
                case "in":
                    // m --> in
                    amount *= 39.3700787;
                    break;
                case "km":
                    // m --> km
                    amount *= 0.001;
                    break;
                case "ft":
                    // m --> ft
                    amount *= 3.2808399;
                    break;
                case "yd":
                    // m --> yd
                    amount *= 1.0936133;
                    break;
                default:
                    Console.WriteLine("Invalid input to.");
                    break;
            }

            Console.WriteLine($"{amount} {to}");
        }
    }
}
