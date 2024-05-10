namespace Sum2
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            Console.Write($"x = ");
            int x = int.Parse(Console.ReadLine());
            Console.Write($"n = ");
            int n = int.Parse(Console.ReadLine());
            double sum = Sum(x, n);
            Console.WriteLine($"The sum is: {sum}");
        }

        static double Sum(int x, int n)
        {
            if(n == 0)
            {
                return 1;
            }
            return Sum(x, n - 1) + Math.Pow(x, n);
        }
    }
}
