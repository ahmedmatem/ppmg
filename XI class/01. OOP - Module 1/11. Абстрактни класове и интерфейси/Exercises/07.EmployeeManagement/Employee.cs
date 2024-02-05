using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    // Abstract class implementing common functionality for employee
    internal abstract class Employee : IEmployee
    {
        protected Employee(string name, string department)
        {
            Name = name;
            Department = department;
        }

        public string Name { get; }
        public string Department { get; }

        public abstract void Display();
    }
}
