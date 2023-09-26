namespace BasicArihmeticOpeaionLabs
{
    internal class TrapezoidArea
    {
        static void Main(string[] args)
        {
            // Reading input
            double b1 = double.Parse(Console.ReadLine());
            double b2 = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            // Calculate trapezoid area by given formula: (b1 + b2) * h / 2
            double area = (b1 + b2) * h / 2;

            // Print rersult
            Console.WriteLine($"Trapeziod area = {area}");
        }
    }
}