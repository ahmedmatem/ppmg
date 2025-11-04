namespace ZooWorld.Lib;

public class Dolphin : Animal, ISwim
{
    public Dolphin(string name, int age) : base(name, age) { }
    public override string MakeSound() => "Click-Whistle!";

    public int TotalSwimM { get; private set; }
    public void Swim(int meters)
    {
        if (meters < 0) throw new ArgumentOutOfRangeException(nameof(meters));
        TotalSwimM += meters;
    }
}
