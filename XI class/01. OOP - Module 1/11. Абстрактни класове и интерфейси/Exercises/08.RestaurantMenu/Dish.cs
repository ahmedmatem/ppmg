using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu
{
    internal class Dish : MenuItem
    {
        public string Category { get; set; }

        public Dish(string name, decimal price, string category) 
            : base(name, price)
        {
            Category = category;
        }

        public override void Display()
        {
            Console.WriteLine($"{Name}({Category}) - {Price}");
        }
    }
}
