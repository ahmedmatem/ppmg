using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleClassHierarchyByAbstraction
{
    internal class Lorry : Vehicle
    {
        public int LoadCapacityTones { get; set; }

        public Lorry(
            string model,
            string brand,
            int year,
            int loadCapacity) 
            : base(model, brand, year)
        {
            LoadCapacityTones = loadCapacity;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Lorry: Model - {Model}, " +
                $"Brand - {Brand}, " +
                $"Year - {Year}, " +
                $"Load capacity - {LoadCapacityTones}");
        }
    }
}
