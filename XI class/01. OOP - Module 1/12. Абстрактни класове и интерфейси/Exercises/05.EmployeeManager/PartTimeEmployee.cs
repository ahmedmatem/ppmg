using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.EmployeeManager
{
    internal class PartTimeEmployee : Employee
    {
        public decimal HourlyRate { get; set; }

        public PartTimeEmployee(string name, string departement, decimal hourlyRate) 
            : base(name, departement)
        {
            HourlyRate = hourlyRate;
        }

        public override void Display()
        {
            Console.WriteLine($"Parttime employee: {Name}, {Departement}, Hourly rate: {HourlyRate}");
        }
    }
}
