namespace PowerCalculator
{
    /// <summary>
    /// Напишете програма, която печата резултата от повдигането 
    /// на число на дадена степен, както в примерите. 
    /// Направете метод, който изчислява и връща резултата като double.
    /// </summary>
    internal class Program
    {

        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            double r = Power(a, n);

            Console.WriteLine(r);
        }

        /// <summary>
        /// Намира и връща 'a' на степен 'n'
        /// </summary>
        static double Power(int a, int n)
        {
            double result = a;
            for(int i = 1; i <= n -1; i++)
            {
                //result = result * a;
                result *= a;
            }
            return result;
        }
    }
}
