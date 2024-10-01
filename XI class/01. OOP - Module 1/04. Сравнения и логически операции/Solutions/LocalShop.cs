namespace LocalShop
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Product's price in Sofia
            double coffeInSofiaPrice = 0.5;
            double waterInSofiaPrice = 0.8;
            double juiceInSofiaPrice = 1.2;
            double sweetsInSofiaPrice = 1.45;
            double peanutsInSofiaPrice = 1.6;

            // Product's price in Plovdiv
            double coffeInPlovdivPrice = 0.4;
            double waterInPlovdivPrice = 0.7;
            double juiceInPlovdivPrice = 1.15;
            double sweetsInPlovdivPrice = 1.3;
            double peanutsInPlovdivPrice = 1.5;

            // Product's price in Varna
            double coffeInVarnaPrice = 0.45;
            double waterInVarnaPrice = 0.7;
            double juiceInVarnaPrice = 1.10;
            double sweetsInVarnaPrice = 1.35;
            double peanutsInVarnaPrice = 1.55;

            // Reading INPUT
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());

            double price = 0;

            if(city == "Sofia")
            {
                // What product and amount of it
                if(product == "coffee")
                {
                    price = coffeInSofiaPrice * amount;
                }
                else if(product == "water")
                {
                    price = waterInSofiaPrice * amount;
                }
                else if(product == "juice")
                {
                    price = juiceInSofiaPrice * amount;
                }
                else if(product == "sweets")
                {
                    price = sweetsInSofiaPrice * amount;
                }
                else
                {
                    // in case oof peanuts product
                    price = peanutsInSofiaPrice * amount;
                }
            }
            else if(city == "Plovdiv")
            {
                // What product and amount of it
                if (product == "coffee")
                {
                    price = coffeInPlovdivPrice * amount;
                }
                else if (product == "water")
                {
                    price = waterInPlovdivPrice * amount;
                }
                else if (product == "juice")
                {
                    price = juiceInPlovdivPrice * amount;
                }
                else if (product == "sweets")
                {
                    price = sweetsInPlovdivPrice * amount;
                }
                else
                {
                    // in case oof peanuts product
                    price = peanutsInPlovdivPrice * amount;
                }
            }
            else if(city == "Varna")
            {
                // Varna
                // What product and amount of it
                if (product == "coffee")
                {
                    price = coffeInVarnaPrice * amount;
                }
                else if (product == "water")
                {
                    price = waterInVarnaPrice * amount;
                }
                else if (product == "juice")
                {
                    price = juiceInVarnaPrice * amount;
                }
                else if (product == "sweets")
                {
                    price = sweetsInVarnaPrice * amount;
                }
                else
                {
                    // in case oof peanuts product
                    price = peanutsInVarnaPrice * amount;
                }
            }

            Console.WriteLine(price);
        }
    }
}
