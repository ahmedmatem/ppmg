namespace SpaceFleet.Lib;

public class Explorer : Ship
{
    public int Discoveries { get; private set; }
    public Explorer(string callSign, int initialEnergy = 150) : base(callSign, initialEnergy) { }

    public void Scan()
    {
        if (Energy < 5) throw new InvalidOperationException("Not enough energy");
        Travel(5);
        Discoveries++;
    }
}
