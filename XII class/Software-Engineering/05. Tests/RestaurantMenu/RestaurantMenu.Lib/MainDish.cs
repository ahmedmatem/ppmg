namespace RestaurantMenu.Lib;

public class MainDish : MenuItem, IVeganFriendly
{
    public bool IsVegan { get; }
    public SpiceLevel Spice { get; }

    public MainDish(string name, decimal price, bool isVegan = false, SpiceLevel spice = SpiceLevel.None)
        : base(name, price)
    {
        IsVegan = isVegan;
        Spice = spice;
    }

    public override string Describe()
        => $"{Name} ({Spice}) - {(IsVegan ? "Vegan" : "Non-Vegan")}";
}
