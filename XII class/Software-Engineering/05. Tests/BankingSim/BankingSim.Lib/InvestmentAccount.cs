namespace BankingSim.Lib;

public class InvestmentAccount : Account, IInterestBearing
{
    public decimal AnnualRate { get; }

    public InvestmentAccount(string owner, decimal initial = 0m, decimal annualRate = 0.06m)
        : base(owner, initial) => AnnualRate = annualRate;

    public override void Withdraw(decimal amount)
    {
        if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
        if (Balance - amount < 0) throw new InvalidOperationException("Insufficient funds");
        Balance -= amount;
    }

    public void ApplyMonthlyInterest()
    {
        var monthly = AnnualRate / 12m;
        Balance += Balance * monthly;
    }
}
