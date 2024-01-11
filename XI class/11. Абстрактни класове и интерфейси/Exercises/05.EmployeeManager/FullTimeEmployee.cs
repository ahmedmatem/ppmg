using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.EmployeeManager
{
    // Concrete employee
    internal class FullTimeEmployee : Employee
    {
        public decimal Salary { get; set; }

        public FullTimeEmployee(string name, string departement, decimal salary) 
            : base(name, departement)
        {
            Salary = salary;
        }

        public override void Display()
        {
            Console.WriteLine($"Fulltime employee: {Name}, {Departement}, Salary: {Salary}");
        }
    }
}
