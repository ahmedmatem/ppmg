namespace TriangleArea
{
    internal class TriangleArea
    {
        static void Main(string[] args)
        {
            // Read input
            double a = double.Parse(Console.ReadLine());
            double ha = double.Parse(Console.ReadLine());

            // Calculate triangle area by formula: a * ha / 2
            double area = a * ha / 2;

            // Round area by Math.Round
            double roundedArea = Math.Round(area, 2);

            // Print result
            Console.WriteLine($"Triangle area = {roundedArea}");
        }
    }
}