using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleClassHierarchyByInheritance
{
    internal class Lorry : Vehicle
    {
        public int LoadCapacityTones { get; set; }

        public Lorry(string model, string brand, int year, int loadCapacityTones)
            : base(model, brand, year)
        {
            LoadCapacityTones = loadCapacityTones;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Lorry: Model - {Model}, " +
                $"Brand - {Brand}, " +
                $"Year - {Year}, " +
                $"Load capacity in tones - {LoadCapacityTones}");
        }
    }
}
