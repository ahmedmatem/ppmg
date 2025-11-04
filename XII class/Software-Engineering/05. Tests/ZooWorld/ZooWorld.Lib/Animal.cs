namespace ZooWorld.Lib;

public abstract class Animal
{
    public string Name { get; }
    public int Age { get; private set; }

    protected Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void Birthday() => Age++;
    public abstract string MakeSound();
}
