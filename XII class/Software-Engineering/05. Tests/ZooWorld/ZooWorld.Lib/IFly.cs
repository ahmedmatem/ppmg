namespace ZooWorld.Lib;

public interface IFly
{
    void Fly(int kilometers);
    int TotalFlightKm { get; }
}
