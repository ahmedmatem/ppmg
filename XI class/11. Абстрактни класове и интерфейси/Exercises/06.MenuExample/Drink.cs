using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuExample
{
    internal class Drink : MenuItem
    {
        public string Size { get; set; }

        public Drink(string name, decimal price, string size) 
            : base(name, price)
        {
            Size = size;
        }

        public override void Display()
        {
            Console.WriteLine($"{Name}[{Size}] - {Price}");
        }
    }
}
