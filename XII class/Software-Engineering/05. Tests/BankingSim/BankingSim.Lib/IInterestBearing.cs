namespace BankingSim.Lib;

public interface IInterestBearing
{
    void ApplyMonthlyInterest();
    decimal AnnualRate { get; }
}
