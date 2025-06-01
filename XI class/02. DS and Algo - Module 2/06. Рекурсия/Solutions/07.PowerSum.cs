namespace _08.PowerSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SumPower(5, 5));
        }

        static double SumPower(int x, int n)
        {
            if(n == 0)
            {
                return 1;
            }

            return SumPower(x, n - 1) + Math.Pow(x, n);
        }
    }
}
