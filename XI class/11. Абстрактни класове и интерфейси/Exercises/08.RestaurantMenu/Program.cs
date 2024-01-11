namespace RestaurantMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMenuItem musaka = new Dish("Musaka", 4.5m, "main dishes");
            IMenuItem spaghettiCarbonara = new Dish("Spaghetti Carbonara", 5.5m, "pasta");
            IMenuItem cocaCola = new Drink("Coca Cola", 1.2m, "midium");
            IMenuItem pepsi = new Drink("Pepsi Cola", 1.35m, "small");
            IMenuItem tiramisu = new Dessert("Tiramisu", 5.95m, "hight");

            Menu menu = new Menu();
            menu.AddMenuItem(musaka);
            menu.AddMenuItem(spaghettiCarbonara);
            menu.AddMenuItem(cocaCola);
            menu.AddMenuItem(pepsi);
            menu.AddMenuItem(tiramisu);

            menu.DisplayMenuItems();
        }
    }
}
