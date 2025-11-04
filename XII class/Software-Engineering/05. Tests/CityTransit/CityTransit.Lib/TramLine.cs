namespace CityTransit.Lib;

public class TramLine : TransitLine
{
    public string HeritageModel { get; }
    public TramLine(string code, string start, string end, TimeSpan plannedDuration, string heritageModel)
        : base(code, start, end, plannedDuration)
    {
        HeritageModel = heritageModel;
    }
}
