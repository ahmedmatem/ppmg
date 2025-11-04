namespace SmartHome.Lib;

public class Thermostat : Device
{
    public double TargetCelsius { get; private set; } = 21.0;
    public Thermostat(string id) : base(id) { }

    public void SetTarget(double celsius)
    {
        if (celsius < 5 || celsius > 35) throw new ArgumentOutOfRangeException(nameof(celsius));
        TargetCelsius = celsius;
    }
}
