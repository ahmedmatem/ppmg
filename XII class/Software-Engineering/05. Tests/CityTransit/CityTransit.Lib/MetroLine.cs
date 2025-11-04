namespace CityTransit.Lib;

public class MetroLine : TransitLine, ISchedulable
{
    public bool Express { get; }
    public int TotalDelay { get; private set; }

    public MetroLine(string code, string start, string end, TimeSpan plannedDuration, bool express = false)
        : base(code, start, end, plannedDuration)
    {
        Express = express;
    }

    public void DelayMinutes(int minutes)
    {
        if (minutes < 0) throw new ArgumentOutOfRangeException(nameof(minutes));
        TotalDelay += minutes;
    }

    public override string Info() => base.Info() + (Express ? " [Express]" : "");
}
