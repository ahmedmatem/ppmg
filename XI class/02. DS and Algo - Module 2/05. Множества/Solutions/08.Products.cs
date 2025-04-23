namespace _09.Products
{
#nullable disable
    internal class Program
    {
        static void Main(string[] args)
        {
            var products = new Dictionary<string, Dictionary<decimal, int>>();

            string line;
            while((line = Console.ReadLine()) != "buy")
            {
                string[] tokens = line.Split(' ');
                string name = tokens[0];
                decimal price = decimal.Parse(tokens[1]);
                int amount = int.Parse(tokens[2]);
                if (products.ContainsKey(name))
                {
                    // contains
                    decimal prevPrice = products[name].Keys.ToArray()[0];
                    int prevAmount = products[name][prevPrice];
                    products[name][price] = prevAmount + amount;
                    if(price != prevPrice)
                    {
                        products[name].Remove(prevPrice);
                    }
                }
                else
                {
                    // does not contain
                    products[name] = new Dictionary<decimal, int>();
                    products[name].Add(price, amount);
                    //products[name][price] = amount;
                }
            }

            foreach (var productName in products.Keys)
            {
                var productValue = products[productName].ToArray()[0];
                Console.WriteLine($"{productName} -> {(productValue.Key * productValue.Value):f2}");
            }
        }
    }
}
