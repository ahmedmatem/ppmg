namespace Square_Equation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ax^2 + bx + c = 0

            // Четем коефициентите a, b и c от един ред разделени с интервал
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int a = numbers[0];
            int b = numbers[1];
            int c = numbers[2];

            double D = 0;
            if(a == 0)
            {
                // linear equation
                if (b != 0)
                {
                    Console.WriteLine($"{(double)c / b}");
                }
                else
                {
                    if (c == 0)
                    {
                        Console.WriteLine("Each x is solution.");
                    }
                    else
                    {
                        Console.WriteLine("No solution.");
                    }
                }
            }
            else
            {
                D = Math.Sqrt(b * b - 4 * a * c);
                if(D < 0)
                {
                    Console.WriteLine("No solution");
                }
                else if(D == 0)
                {
                    Console.WriteLine($"x1,2 = {-b / (2.0 * a)}");
                }
                else
                {
                    Console.WriteLine($"x1 = {(-b + D) / (2.0 * a)}, x2 = {(-b - D) / (2.0 * a)}");
                }
            }
        }
    }
}