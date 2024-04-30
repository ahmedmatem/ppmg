using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelForLive
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.For(0, 21,
                (i) =>
                {
                    Console.WriteLine(i);
                });

            //for (int i = 0; i < 21; i++)
            //{
            //    Console.WriteLine(i);
            //}
        }
    }
}
