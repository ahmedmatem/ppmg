namespace ZooWorld.Lib;

public class Lion : Animal
{
    public Lion(string name, int age) : base(name, age) { }
    public override string MakeSound() => "Roar!";
}
