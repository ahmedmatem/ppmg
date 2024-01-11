using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.EmployeeManager
{
    // Employee implementing the common functionality for employee
    internal abstract class Employee : IEmployee
    {
        protected Employee(string name, string departement)
        {
            Name = name;
            Departement = departement;
        }

        public string Name { get; }
        public string Departement { get; }

        public abstract void Display();
    }
}
