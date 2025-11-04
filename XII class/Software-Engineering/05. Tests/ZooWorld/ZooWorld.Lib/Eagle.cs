namespace ZooWorld.Lib;

public class Eagle : Animal, IFly
{
    public Eagle(string name, int age) : base(name, age) { }
    public override string MakeSound() => "Screech!";

    public int TotalFlightKm { get; private set; }
    public void Fly(int kilometers)
    {
        if (kilometers < 0) throw new ArgumentOutOfRangeException(nameof(kilometers));
        TotalFlightKm += kilometers;
    }
}
