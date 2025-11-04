namespace SmartHome.Lib;

public class LightBulb : Device
{
    public int Brightness { get; private set; } // 0..100

    public LightBulb(string id) : base(id) { }

    public void SetBrightness(int value)
    {
        if (value is < 0 or > 100) throw new ArgumentOutOfRangeException(nameof(value));
        Brightness = value;
    }
}
