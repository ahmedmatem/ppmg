namespace _03.Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 22;
            int n = 10;
            double sum = CalculateSum(x, n);
            double sumIteration = CalculateSumByIterations(x, n);

            Console.WriteLine($"sum = {sum}");
            Console.WriteLine($"By iterations - sum = {sumIteration}");
        }

        static double CalculateSumByIterations(double x, double n)
        {
            double result = 0;
            for (int i = 0; i <= n; i++)
            {
                result += 1 / ((x + i) * (x + i + 1));
            }

            return result;
        }

        static double CalculateSum(double x, double n)
        {
            if (n == 0)
            {
                return 1 / ((x * (x + 1)));
            }
            return CalculateSum(x, n - 1) + 1 / ((x + n) * (x + n + 1));
        }
    }
}
