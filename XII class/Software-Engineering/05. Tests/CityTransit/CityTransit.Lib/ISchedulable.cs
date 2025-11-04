namespace CityTransit.Lib;

public interface ISchedulable
{
    void DelayMinutes(int minutes);
    int TotalDelay { get; }
}
