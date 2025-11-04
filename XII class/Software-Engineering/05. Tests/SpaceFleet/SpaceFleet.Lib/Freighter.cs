namespace SpaceFleet.Lib;

public class Freighter : Ship
{
    public int CargoTons { get; private set; }
    public Freighter(string callSign, int initialEnergy = 200) : base(callSign, initialEnergy) { }
    public void Load(int tons) { if (tons < 0) throw new ArgumentOutOfRangeException(nameof(tons)); CargoTons += tons; }
    public void Unload(int tons) { if (tons < 0 || tons > CargoTons) throw new ArgumentOutOfRangeException(nameof(tons)); CargoTons -= tons; }
}
