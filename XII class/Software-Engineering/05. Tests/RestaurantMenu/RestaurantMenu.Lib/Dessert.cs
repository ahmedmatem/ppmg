namespace RestaurantMenu.Lib;

public class Dessert : MenuItem
{
    public int Calories { get; }

    public Dessert(string name, decimal price, int calories)
        : base(name, price)
    {
        if (calories < 0) throw new ArgumentOutOfRangeException(nameof(calories));
        Calories = calories;
    }

    public override string Describe() => $"{Name} - {Calories} kcal";
}
