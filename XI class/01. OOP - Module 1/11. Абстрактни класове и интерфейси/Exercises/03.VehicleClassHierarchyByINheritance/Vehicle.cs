using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleClassHierarchyByInheritance
{
    internal class Vehicle
    {
        public Vehicle(string model, string brand, int year)
        {
            Model = model;
            Brand = brand;
            Year = year;
        }

        public string Model { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Vehicle: Model - {Model}, Brand - {Brand}, Year - {Year}");
        }
    }
}
