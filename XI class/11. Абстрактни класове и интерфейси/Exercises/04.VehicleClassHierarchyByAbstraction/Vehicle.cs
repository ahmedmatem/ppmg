using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleClassHierarchyByAbstraction
{
    internal abstract class Vehicle : IVehicle
    {
        protected Vehicle(
            string model,
            string brand,
            int year)
        {
            Model = model;
            Brand = brand;
            Year = year;
        }

        public string Model { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }

        public abstract void DisplayInfo();
    }
}
