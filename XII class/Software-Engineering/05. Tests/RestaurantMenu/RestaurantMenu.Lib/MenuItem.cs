namespace RestaurantMenu.Lib;

public abstract class MenuItem
{
    public string Name { get; }
    public decimal Price { get; private set; }

    protected MenuItem(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name required");
        if (price < 0) throw new ArgumentOutOfRangeException(nameof(price));
        Name = name;
        Price = price;
    }

    public void ChangePrice(decimal newPrice)
    {
        if (newPrice < 0) throw new ArgumentOutOfRangeException(nameof(newPrice));
        Price = newPrice;
    }

    public abstract string Describe();
}
