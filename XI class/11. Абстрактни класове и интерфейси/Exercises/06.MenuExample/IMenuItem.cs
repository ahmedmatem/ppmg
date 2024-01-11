using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuExample
{
    internal interface IMenuItem
    {
        string Name { get; }
        decimal Price { get; }
        void Display();
    }
}
