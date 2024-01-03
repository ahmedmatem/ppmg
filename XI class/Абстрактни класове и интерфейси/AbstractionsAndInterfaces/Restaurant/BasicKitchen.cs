using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class BasicKitchen : IKitchen
    {
        public void PrepareMusaka()
        {
            Console.WriteLine("Preparing musaka");
        }

        public void PrepareSoup()
        {
            Console.WriteLine("Preparing soup");
            BoilingWater();
        }

        public void PrepareSpaghetti()
        {
            Console.WriteLine("Preparing spaghetti");
            BoilingWater();
        }

        public void BoilingWater()
        {
            Console.WriteLine("Boiling water");
        }

        public int ChefsCount { get; set; }
    }
}
