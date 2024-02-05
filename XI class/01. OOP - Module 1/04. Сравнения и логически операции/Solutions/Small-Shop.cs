using System;

namespace Small_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            const double coffeeVarna = 0.45;
            const double waterVarna = 0.70;
            const double juiceVarna = 1.10;
            const double sweetsVarna = 1.35;
            const double peanutsVarna = 1.55;
            		
            const double coffeeSofia = 0.50;
            const double waterSofia = 0.80;
            const double juiceSofia = 1.20;
            const double sweetsSofia = 1.45;
            const double peanutsSofia = 1.60;

            const double coffeePlovdiv = 0.40;
            const double waterPlovdiv = 0.70;
            const double juicePlovdiv = 1.15;
            const double sweetsPlovdiv = 1.30;
            const double peanutsPlovdiv = 1.50;


            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());

            double price = 0;

            switch (city)
            {
                case "Varna":
                    if(product == "coffee")
                    {
                        price = amount * coffeeVarna;
                    }
                    else if(product == "water")
                    {
                        price = amount * waterVarna;
                    }
                    else if(product == "juice")
                    {
                        price = amount * juiceVarna;
                    }
                    else if(product == "sweets")
                    {
                        price = amount * sweetsVarna;
                    }
                    else if(product == "peanuts")
                    {
                        price = amount * peanutsVarna;
                    }
                    break;
                case "Sofia":
                    if (product == "coffee")
                    {
                        price = amount * coffeeSofia;
                    }
                    else if (product == "water")
                    {
                        price = amount * waterSofia;
                    }
                    else if (product == "juice")
                    {
                        price = amount * juiceSofia;
                    }
                    else if (product == "sweets")
                    {
                        price = amount * sweetsSofia;
                    }
                    else if (product == "peanuts")
                    {
                        price = amount * peanutsSofia;
                    }

                    break;
                case "Plovdiv":
                    if (product == "coffee")
                    {
                        price = amount * coffeePlovdiv;
                    }
                    else if (product == "water")
                    {
                        price = amount * waterPlovdiv;
                    }
                    else if (product == "juice")
                    {
                        price = amount * juicePlovdiv;
                    }
                    else if (product == "sweets")
                    {
                        price = amount * sweetsPlovdiv;
                    }
                    else if (product == "peanuts")
                    {
                        price = amount * peanutsPlovdiv;
                    }

                    break;
                default:
                    break;
            }

            Console.WriteLine(price);
        }
    }
}
