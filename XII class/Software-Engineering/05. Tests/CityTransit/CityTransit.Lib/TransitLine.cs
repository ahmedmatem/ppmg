namespace CityTransit.Lib;

public abstract class TransitLine
{
    public string Code { get; }
    public string Start { get; }
    public string End { get; }
    public TimeSpan PlannedDuration { get; }

    protected TransitLine(string code, string start, string end, TimeSpan plannedDuration)
    {
        Code = code;
        Start = start;
        End = end;
        PlannedDuration = plannedDuration;
    }

    public virtual string Info() => $"{Code}: {Start} → {End} ({PlannedDuration.TotalMinutes} min)";
}
