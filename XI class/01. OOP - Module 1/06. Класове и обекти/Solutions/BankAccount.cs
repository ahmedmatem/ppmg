namespace ClassDemo
{
    public class BankAccount
    {
        // Полета (Fields)
        private decimal balance;

        // Свойства (Properties)
        public int Accountnumber { get; set; }
        public string Owner { get; set; }
        public decimal Balance 
        {
            get { return balance; }
            set
            {
                if(value < 0)
                {
                    Console.WriteLine("Balance must be zero or positive number.");
                }
                else
                {
                    balance = value;
                }
            }
        }

        // Конструктори (Constructors)

        public BankAccount(int accountNumber, string owner)
        {
            Accountnumber = accountNumber;
            Owner = owner;
            Balance = 0;
        }

        public BankAccount(int accountnumber, string owner, decimal balance)
            : this(accountnumber, owner)
        {
            Balance = balance;
        }

        // Методи (Methods)

        public void Deposit(decimal amount)
        {
            if(Balance + amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Deposit completed successfully. New balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Deposit process interrupted unexpectedly.");
            }
        }

        public void Withdraw(decimal amount)
        {
            if(balance - amount >= 0)
            {
                Balance -= amount;
                Console.WriteLine($"Withdraw completed successfully. New balnce: {Balance}");
            }
            else
            {
                Console.WriteLine("Withdraw was interrupted unexpectedly.");
            }
        }

        public void DisplayAccountInfo()
        {
            Console.WriteLine("Account Information");
            Console.WriteLine("===================");
            Console.WriteLine($"Owner: {Owner}");
            Console.WriteLine($"Account number: {Accountnumber}");
            Console.WriteLine($"Balance: {Balance}");
        }
    }
}
