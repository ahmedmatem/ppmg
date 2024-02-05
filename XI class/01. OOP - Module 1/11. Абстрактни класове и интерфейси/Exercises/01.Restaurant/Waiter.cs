using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class Waiter
    {
        private IKitchen kitchen = new BasicKitchen();

        public void MakeOrder(string orderName)
        {
            switch(orderName)
            {
                case "spaghetti":
                    kitchen.PrepareSpaghetti();
                    break;
                case "soup":
                    kitchen.PrepareSoup();
                    break;
                case "musaka":
                    kitchen.PrepareMusaka();
                    break;
                default:
                    break;
            }
        }
    }
}
