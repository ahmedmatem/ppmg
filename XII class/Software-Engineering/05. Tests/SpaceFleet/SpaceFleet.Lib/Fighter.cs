namespace SpaceFleet.Lib;

public class Fighter : Ship, IWeaponSystem
{
    public Fighter(string callSign, int initialEnergy = 120) : base(callSign, initialEnergy) { }

    public int Fire(int energyRequested)
    {
        if (energyRequested <= 0) throw new ArgumentOutOfRangeException(nameof(energyRequested));
        if (Energy < energyRequested) throw new InvalidOperationException("Not enough energy to fire");
        Travel(energyRequested); // spend energy
        return energyRequested * 2; // damage dealt
    }
}
