namespace ClassDemo
{
    public class Product
    {
        // Полета (Fields)

        private decimal price;
        private int quantity;

        // Свойства (Properties)

        public string Name { get; set; }
        public decimal Price 
        {
            get { return price; }
            set
            {
                if (value > 0)
                {
                    price = value;
                }
                else
                {
                    Console.WriteLine("The product price must be positive number.");
                }
            }
        }
        public int Quantity 
        {
            get { return quantity; }
            set
            {
                if(value > 0)
                {
                    quantity = value;
                }
                else
                {
                    Console.WriteLine("The product quantity must be positive number.");
                }
            }
        }

        // Конструктори (Constructors)

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

        // Методи (Methods)

        public void Restock(int amount)
        {
            if(amount > 0)
            {
                Quantity += amount;
                Console.WriteLine($"Restock completed successfully. Product quantity: {Quantity}");
            }
            else
            {
                Console.WriteLine("Restock amount must be positive number. Oeration was rejected.");
            }
        }

        public void Sell(int amount)
        {
            if(Quantity - amount >= 0)
            {
                Quantity -= amount;
                Console.WriteLine($"{amount} items was sold. Product quantity in stock: {Quantity}");
            }
            else
            {
                Console.WriteLine("Insufficient quantity of the product.");
            }
        }

        public void DisplayProductInfo()
        {
            Console.WriteLine("Product Information");
            Console.WriteLine("-------------------");
            Console.WriteLine($"Product name: {Name}");
            Console.WriteLine($"Product price: {Price}");
            Console.WriteLine($"Product quantity: {Quantity}");
        }
    }
}
