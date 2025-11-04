namespace SpaceFleet.Lib;

public abstract class Ship
{
    public string CallSign { get; }
    public int Energy { get; private set; }

    protected Ship(string callSign, int initialEnergy = 100)
    {
        CallSign = callSign;
        Energy = initialEnergy;
    }

    public virtual void Recharge(int amount)
    {
        if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
        Energy += amount;
    }

    public void Travel(int cost)
    {
        if (cost < 0) throw new ArgumentOutOfRangeException(nameof(cost));
        if (Energy < cost) throw new InvalidOperationException("Not enough energy");
        Energy -= cost;
    }
}
