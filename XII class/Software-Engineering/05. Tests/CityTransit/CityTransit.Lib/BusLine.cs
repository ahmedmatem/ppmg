namespace CityTransit.Lib;

public class BusLine : TransitLine, ISchedulable
{
    public int Stops { get; }
    public int TotalDelay { get; private set; }

    public BusLine(string code, string start, string end, TimeSpan plannedDuration, int stops)
        : base(code, start, end, plannedDuration)
    {
        if (stops <= 0) throw new ArgumentOutOfRangeException(nameof(stops));
        Stops = stops;
    }

    public void DelayMinutes(int minutes)
    {
        if (minutes < 0) throw new ArgumentOutOfRangeException(nameof(minutes));
        TotalDelay += minutes;
    }
}
