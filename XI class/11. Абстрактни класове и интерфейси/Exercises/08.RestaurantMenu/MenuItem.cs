using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu
{
    // Abstract class implementing common functionality of a menu item
    internal abstract class MenuItem : IMenuItem
    {
        protected MenuItem(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; }

        public decimal Price { get; }

        public abstract void Display();
    }
}
