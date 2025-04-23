namespace FoodAndWineShop
{

//lidl, juice, 2.30
//fantastico, apple, 1.20
//kaufland, banana, 1.10
//fantastico, grape, 2.20
//Revision


    internal class Program
    {
        #nullable disable
        static void Main(string[] args)
        {

            var r = new Random();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(r.Next(20, 30));
            }

            //var shops = new Dictionary<string, Dictionary<string, decimal>>();

            //string line = Console.ReadLine();
            //while(line != "Revision")
            //{
            //    string[] lineParts = line
            //        .Split(',', ' ', StringSplitOptions.RemoveEmptyEntries);
            //    //.Split(", ");
            //    string shopName = lineParts[0];
            //    string productName = lineParts[1];
            //    decimal productPrice = decimal.Parse(lineParts[2]);

            //    if (!shops.ContainsKey(shopName))
            //    {
            //        shops[shopName] = new Dictionary<string, decimal>();
            //    }
            //    shops[shopName][productName] = productPrice;

            //    line = Console.ReadLine();
            //}

            //foreach (var shop in shops.Keys)
            //{
            //    Console.WriteLine($"{shop}->");
            //    foreach (var keyValuePair in shops[shop])
            //    {
            //        string productName = keyValuePair.Key;
            //        decimal productPrice = keyValuePair.Value;
            //        Console.WriteLine($"Product: {productName}, Price: {productPrice}");
            //    }
            //}
        }
    }
}
