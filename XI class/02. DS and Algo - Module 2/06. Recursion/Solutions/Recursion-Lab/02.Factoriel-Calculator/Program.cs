using System.Diagnostics;

namespace _02.Factoriel_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long result = F(n);
            Console.WriteLine($"{n}! = {result}");
        }

        static long F(int n)
        {
            if(n == 1)
            {
                return 1;
            }
            return F(n - 1) * n;
        }

    }
}
