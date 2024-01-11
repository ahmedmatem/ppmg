using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    // Interface defining the basic functionalities of an employee
    internal interface IEmployee
    {
        string Name { get; }
        string Department { get; }
        void Display();
    }
}
