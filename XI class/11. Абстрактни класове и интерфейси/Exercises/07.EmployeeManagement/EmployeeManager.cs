using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    // Class EmployeeManager managing the collection of employees
    internal class EmployeeManager
    {
        private List<IEmployee> employees;

        public EmployeeManager()
        {
            employees = new List<IEmployee>();
        }

        public void AddEmployee(IEmployee employee)
        {
            employees.Add(employee);
        }

        public void DisplayEmployees()
        {
            Console.WriteLine("List of employees:");
            foreach (IEmployee employee in employees)
            {
                employee.Display();
            }

        }
    }
}
