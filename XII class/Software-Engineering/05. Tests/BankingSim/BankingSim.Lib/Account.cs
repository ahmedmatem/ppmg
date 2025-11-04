namespace BankingSim.Lib;

public abstract class Account
{
    public string Owner { get; }
    public decimal Balance { get; protected set; }

    protected Account(string owner, decimal initial = 0m)
    {
        Owner = owner;
        Balance = initial;
    }

    public virtual void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
        Balance += amount;
    }

    public abstract void Withdraw(decimal amount);
}
