using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu
{
    internal class Dessert : MenuItem
    {
        public string SweetnessLevevl { get; set; }

        public Dessert(string name, decimal price, string sweetneLevel) 
            : base(name, price)
        {
            SweetnessLevevl = sweetneLevel;
        }

        public override void Display()
        {
            Console.WriteLine($"{Name}({SweetnessLevevl}) - {Price}");
        }
    }
}
