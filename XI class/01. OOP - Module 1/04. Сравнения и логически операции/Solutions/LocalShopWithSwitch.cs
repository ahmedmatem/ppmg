namespace _11._LocalShopWithSwitch
{
    internal class Program
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

            switch (city)
            {
                case "Sofia":
                    switch (product)
                    {
                        case "coffee":
                            price = coffeInSofiaPrice * amount;
                            break;
                        case "water":
                            price = waterInSofiaPrice * amount;
                            break;
                        case "juice":
                            price = juiceInSofiaPrice * amount;
                            break;
                        case "sweets":
                            price = sweetsInSofiaPrice * amount;
                            break;
                        case "peanuts":
                            price = peanutsInSofiaPrice * amount;
                            break;
                        default:
                            break;
                    }
                    break;
                case "Plovdiv":
                    switch (product)
                    {
                        case "coffee":
                            price = coffeInPlovdivPrice * amount;
                            break;
                        case "water":
                            price = waterInPlovdivPrice * amount;
                            break;
                        case "juice":
                            price = juiceInPlovdivPrice * amount;
                            break;
                        case "sweets":
                            price = sweetsInPlovdivPrice * amount;
                            break;
                        case "peanuts":
                            price = peanutsInPlovdivPrice * amount;
                            break;
                        default:
                            break;
                    }
                    break;
                case "Varna":
                    switch (product)
                    {
                        case "coffee":
                            price = coffeInVarnaPrice * amount;
                            break;
                        case "water":
                            price = waterInVarnaPrice * amount;
                            break;
                        case "juice":
                            price = juiceInVarnaPrice * amount;
                            break;
                        case "sweets":
                            price = sweetsInVarnaPrice * amount;
                            break;
                        case "peanuts":
                            price = peanutsInVarnaPrice * amount;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            Console.WriteLine(price);
        }
    }
}
