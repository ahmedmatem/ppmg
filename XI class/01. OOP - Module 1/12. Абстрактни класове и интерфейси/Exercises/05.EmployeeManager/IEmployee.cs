using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.EmployeeManager 
{
    // IEmployee defines basic functionalities of an employee
    internal interface IEmployee
    {
        string Name { get; }
        string Departement { get; }
        void Display();
    }
}
