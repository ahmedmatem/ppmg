using GroceryStore2.Data;
using GroceryStore2.Data.Models;

namespace GroceryStore2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new AppDbContext();
            var result = GetAllByUnit(dbContext, "meter");

            Console.WriteLine("All products with unit type: meter");
            Console.WriteLine(new string('=', 25));
            foreach (var product in result)
            {
                //Console.WriteLine("{0} - {1} per {2}", product.Name, product.Price, product.UnitType);
                                
                Console.WriteLine($"{product.Name} - {product.Price} per {product.UnitType}");
            }
        }

        private static List<Product> GetAllByUnit(AppDbContext context, string unit)
        {
            var productsByUnit = context.Products
                .Where(p => p.UnitType == unit)
                .ToList();

            if (productsByUnit is null)
            {
                return [];
            }

            return productsByUnit;
        }
    }
}
