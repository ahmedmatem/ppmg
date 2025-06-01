namespace FActorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(n));
        }

        static long Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }

        //static long IterFactorial(long n)
        //{
        //    long result = 1;
        //    for (int i = 1; i <= n; i++)
        //    {
        //        result *= i;
        //    }

        //    return result;
        //}
    }
}
