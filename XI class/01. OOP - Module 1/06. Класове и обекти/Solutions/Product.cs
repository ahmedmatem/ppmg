using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemo
{
    public class Product
    {
		// Полета
		private string name;
        private decimal price;
        private int quantity;

		// Свойства
        public string Name
		{
			get { return name; }
			set 
			{ 
				if(!string.IsNullOrWhiteSpace(value) && value.Length > 2)
				{
					name = value;
				}
				else
				{
                    Console.WriteLine("Name must be bigger than 2 symbols.");
				}
			}			
		}		

		public decimal Price
		{
			get { return price; }
			set 
			{ 
				if(value >= 0)
				{
                    price = value;
                }
				else
				{
                    Console.WriteLine("Price must be positive number.");
				}
			}
		}		

		public int Quantity
		{
			get { return quantity; }
			set
			{
                if (value > 0)
                {
                    quantity = value;
                }
                else
                {
                    Console.WriteLine("Quantity must be positive number.");
                }
            }
		}

		// Конструктори
		public Product(string name)
		{
			Name = name;
			Price = 0;
			Quantity = 1;
		}

		public Product(string name, decimal price, int quantity)
			: this(name)
		{
			Price = price;
			Quantity = quantity;
		}

		// Методи
		public void Restock(int amount)
		{
			if (amount > 0)
			{
				Quantity += amount;
                Console.WriteLine($"Restock of {amount} items completed successfully.");
                Console.WriteLine($"New quantity: {Quantity}.");
			}
			else
			{
                Console.WriteLine("Product amount must be positive number.");
			}
		}

		public void Sell(int amount)
		{
			if(Quantity >= amount && amount > 0)
			{
				Quantity -= amount;
                Console.WriteLine($"Selling completed successfully. New quantity: {Quantity}");
			}
			else
			{
                Console.WriteLine("Imposible selling of product.");
			}
		}

		public void DisplayProductInfo()
		{
			Console.WriteLine();
            Console.WriteLine($"Product: {Name}, Price: {Price}, Quantity: {Quantity}.");
            Console.WriteLine();
		}
    }
}
