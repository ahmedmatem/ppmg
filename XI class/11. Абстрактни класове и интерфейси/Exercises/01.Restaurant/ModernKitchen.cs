using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class ModernKitchen : IKitchen
    {
        public void PrepareMusaka()
        {
            Console.WriteLine("Preaparing modern musaka");
            CutProduct("potatoes");
            CutProduct("onions");
            ModernWaterBoiling();
        }

        public void PrepareSoup()
        {
            Console.WriteLine("Modern soup preparation.");
        }

        public void PrepareSpaghetti()
        {
            Console.WriteLine("Modern spaghetti.");
            ModernWaterBoiling();
        }

        public void ModernWaterBoiling()
        {
            Console.WriteLine("Boiling water by new modern technology.");
        }

        public void CutProduct(string productName)
        {
            Console.WriteLine($"Cutting {productName}");
        }
    }
}
