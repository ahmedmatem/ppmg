using System.Runtime.CompilerServices;

namespace _06.FibonachySequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(F(10));
        }

        static int F(int n)
        {
            //if(n < 2)
            //{
            //    return n;
            //}

            return F(n - 1) + F(n - 2);
        }
    }
}
