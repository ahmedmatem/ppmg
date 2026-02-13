using GroceryStore.Data;

namespace GroceryStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new AppDbContext();

            foreach (var product in context.Products)
            {
                Console.WriteLine($"{product.Name} - {product.Price} per {product.UnitType}");
            }
        }
    }
}
