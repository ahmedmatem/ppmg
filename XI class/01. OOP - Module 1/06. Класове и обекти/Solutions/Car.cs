using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemo
{
    public class Car
    {
        // Полета (Fields)
        private int year;
        private decimal fuelLevel;

        // Свойства (Properties)
        public string Make { get; set; }
        public string Model { get; set; }        

        public int Year
        {
            get { return year; }
            set 
            { 
                if(value >= 2000 && value <= DateTime.Now.Year)
                {
                    year = value;
                }
                else
                {
                    Console.WriteLine("Invalid car year.");
                }
            }
        }       

        public decimal FuelLevel
        {
            get { return fuelLevel; }
            set 
            { 
                if(value >= 0 && value <= 60)
                {
                    fuelLevel = value;
                }
                else
                {
                    Console.WriteLine("Invalid fuel level.");
                }
            }
        }

        // Конструктори (Constructors)

        // default constructor
        public Car()
        {
            Make = "Unknown";
            Model = "Unknown";
            Year = 2000;
            FuelLevel = 0;
        }

        public Car(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public Car(string make, string model, int year, decimal fuelLevel)
            : this(make, model, year)
        {
            FuelLevel = fuelLevel;
        }

        // Методи (Methods)
        public void Drive(decimal distance)
        {
            decimal fuelConsumed = distance * 0.1m; // разход: 1 литър на 10км
            if(FuelLevel >= fuelConsumed)
            {
                FuelLevel -= fuelConsumed;
                Console.WriteLine($"The car travelled {distance}km.");
                Console.WriteLine($"Fuel level: {FuelLevel}");
            }
            else
            {
                Console.WriteLine("Insufficient fuel level.");
            }
        }

        public void Refuel(decimal fuelAmount)
        {
            if(FuelLevel + fuelAmount <= 60)
            {
                Console.WriteLine("The car was refuelled successfully.");
                FuelLevel += fuelAmount;
                Console.WriteLine($"The fuel level is {FuelLevel}");
            }
            else
            {
                Console.WriteLine("Too much fuel to refuel.");
                Console.WriteLine("Refuel process was interrupted.");
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Car information");
            Console.WriteLine("===============");
            Console.WriteLine($"Make: {Make}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Year: {Year}");
            Console.WriteLine($"Fuel level: {FuelLevel}");
            Console.WriteLine();
        }
    }
}
