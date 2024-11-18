using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleClassHierarchyByAbstraction
{
    internal class Car : Vehicle
    {
        public int NumOfDoors { get; set; }

        public Car(string model, string brand, int year, int numOfDoors) 
            : base(model, brand, year)
        {
            NumOfDoors = numOfDoors;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Car: Model - {Model}, " +
                $"Brand - {Brand}, " +
                $"Year - {Year}, " +
                $"Doors - {NumOfDoors}");
        }
    }
}
