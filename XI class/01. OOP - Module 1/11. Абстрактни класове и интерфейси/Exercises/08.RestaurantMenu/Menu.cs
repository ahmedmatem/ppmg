using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu
{
    internal class Menu
    {
        private List<IMenuItem> menuItems;

        public Menu()
        {
            menuItems = new List<IMenuItem>();
        }

        public void AddMenuItem(IMenuItem item)
        {
            menuItems.Add(item);
        }

        public void DisplayMenuItems()
        {
            Console.WriteLine("===== MENU =====");
            foreach (IMenuItem item in menuItems)
            {
                item.Display();
            }
        }
    }
}
