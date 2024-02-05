using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    internal class PartTimeEmployee : Employee
    {
        // Concrete class representing a part-time employee
        public decimal HourlyRate { get; set; }

        public PartTimeEmployee(string name, string department, decimal hourlyRate)
            : base(name, department)
        {
            HourlyRate = hourlyRate;
        }

        public override void Display()
        {
            Console.WriteLine($"{Name} - {Department}, Rate - {HourlyRate}");
        }
    }
}
