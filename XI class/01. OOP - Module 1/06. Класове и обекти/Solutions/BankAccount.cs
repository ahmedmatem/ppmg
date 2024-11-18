using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemo
{
    public class BankAccount
    {
		// Полета
		private string accountNumber;
        private decimal balance;

		// Свойства
        public string AccountNumber
		{
			get { return accountNumber; }
			set 
			{
				if(value.Length == 10)
				{
					accountNumber = value;
				}
				else
				{
                    Console.WriteLine("Account number must be 10 symbols.");
				}
			}
		}
        public string Owner { get; set; }	
		public decimal Balance
		{
			get { return balance; }
			set 
			{ 
				if(value > 0)
				{
                    balance = value;
                }
				else
				{
                    Console.WriteLine("Balance must be positive number.");
				}
			}
		}

		// конструктори
		public BankAccount(string accountNum, string owner)
		{
			AccountNumber = accountNum;
			Owner = owner;
		}

        public BankAccount(string accountNum, string owner, decimal balance)
			: this(accountNum, owner)
        {
			Balance = balance;
        }

		// Методи

		public void Deposit(decimal amount)
		{
			Balance += amount;
            Console.WriteLine($"Deposit is done. New balance: {Balance}.");
		}

		public void Withdraw(decimal amount)
		{
			if(Balance >= amount)
			{
				Balance -= amount;
                Console.WriteLine($"Withdraw is done. New balance: {Balance}.");
			}
			else
			{
                Console.WriteLine($"Insufficient amount. Balance: {Balance}");
			}
		}

		public void DisplayAccountInfo()
		{
            //Console.WriteLine();
            //Console.WriteLine("=========== Bank account information ==========");
            //Console.WriteLine("------------------------------------------------");
            //Console.WriteLine($"Account number: {AccountNumber}");
            //Console.WriteLine($"Account owner: {Owner}");
            //Console.WriteLine($"Account balance: {Balance}");
            //Console.WriteLine("------------------------------------------------");
            //Console.WriteLine();

			Console.WriteLine($"Bank account: {AccountNumber} for {Owner} with balance {Balance}.");
		}
    }
}
