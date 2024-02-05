using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    // Concrete class representing a full-time employee
    internal class FullTimeEmployee : Employee
    {
        public decimal Salary { get; set; }

        public FullTimeEmployee(string name, string department, decimal salary) 
            : base(name, department)
        {
            Salary = salary;
        }

        public override void Display()
        {
            Console.WriteLine($"{Name} - {Department}, Salary - {Salary}");
        }
    }
}
