using System;


namespace Fruit_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            const double bananaWorkdayPrice = 2.50;
            const double appleWorkdayPrice = 1.20;
            const double orangeWorkdayPrice = 0.85;
            const double grapefruitWorkdayPrice = 1.45;
            const double kiwiWorkdayPrice = 2.70;
            const double pineappleWorkdayPrice = 5.50;
            const double grapesWorkdayPrice = 3.85;

            const double bananaWeekendPrice = 2.70;
            const double appleWeekendPrice = 1.25;
            const double orangeWeekendPrice = 0.90;
            const double grapefruitWeekendPrice = 1.60;
            const double kiwiWeekendPrice = 3.00;
            const double pineappleWeekendPrice = 5.60;
            const double grapesWeekendPrice = 4.20;

            // banana	apple	orange	grapefruit	kiwi	pineapple	grapes
            double price = 0;
            if (day == "Monday"
                || day == "Tuesday"
                || day == "Wednesday"
                || day == "Thursday"
                || day == "Friday")
            {
                switch (fruit)
                {
                    case "banana":
                        price = quantity * bananaWorkdayPrice;
                        break;
                    case "apple":
                        price = quantity * appleWorkdayPrice;
                        break;
                    case "orange":
                        price = quantity * orangeWorkdayPrice;
                        break;
                    case "grapefruit":
                        price = quantity * grapefruitWorkdayPrice;
                        break;
                    case "kiwi":
                        price = quantity * kiwiWorkdayPrice;
                        break;
                    case "pineapple":
                        price = quantity * pineappleWorkdayPrice;
                        break;
                    case "grapes":
                        price = quantity * grapesWorkdayPrice;
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else if (day == "Saturday" || day == "Sunday")
            {
                // weekend
                switch (fruit)
                {
                    case "banana":
                        price = quantity * bananaWeekendPrice;
                        break;
                    case "apple":
                        price = quantity * appleWeekendPrice;
                        break;
                    case "orange":
                        price = quantity * orangeWeekendPrice;
                        break;
                    case "grapefruit":
                        price = quantity * grapefruitWeekendPrice;
                        break;
                    case "kiwi":
                        price = quantity * kiwiWeekendPrice;
                        break;
                    case "pineapple":
                        price = quantity * pineappleWeekendPrice;
                        break;
                    case "grapes":
                        price = quantity * grapesWeekendPrice;
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else
            {
                Console.WriteLine("error");
            }

            if(price != 0)
            {
                Console.WriteLine($"{price:F2}");
            }
            
        }
    }
}