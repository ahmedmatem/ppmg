namespace BankingSim.Lib;

public class CheckingAccount : Account
{
    public decimal OverdraftLimit { get; }

    public CheckingAccount(string owner, decimal initial = 0m, decimal overdraftLimit = 200m)
        : base(owner, initial) => OverdraftLimit = overdraftLimit;

    public override void Withdraw(decimal amount)
    {
        if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
        if (Balance - amount < -OverdraftLimit) throw new InvalidOperationException("Overdraft exceeded");
        Balance -= amount;
    }
}
