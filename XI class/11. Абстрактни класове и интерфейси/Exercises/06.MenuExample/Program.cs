namespace MenuExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMenuItem cocaColaDrink = new Drink("Coca Cola", 1.8m, "medium");
            IMenuItem pepsiDrink = new Drink("Pepsi", 2.2m, "small");
            IMenuItem carbonaraDish = new Dish("Spaghetti Carbonara", 1.2m, "pasta");

            Menu menu = new Menu();
            menu.AddMenuItem(cocaColaDrink);
            menu.AddMenuItem(pepsiDrink);
            menu.AddMenuItem (carbonaraDish);

            menu.DisplayMenuItems();
        }
    }
}
