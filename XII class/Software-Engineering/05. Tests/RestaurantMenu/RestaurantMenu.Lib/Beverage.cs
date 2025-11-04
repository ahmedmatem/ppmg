namespace RestaurantMenu.Lib;

public class Beverage : MenuItem
{
    public bool IsAlcoholic { get; }
    public double VolumeMl { get; }

    public Beverage(string name, decimal price, double volumeMl, bool isAlcoholic = false)
        : base(name, price)
    {
        if (volumeMl <= 0) throw new ArgumentOutOfRangeException(nameof(volumeMl));
        IsAlcoholic = isAlcoholic;
        VolumeMl = volumeMl;
    }

    public override string Describe() => $"{Name} - {VolumeMl} ml" + (IsAlcoholic ? " (18+)" : "");
}
