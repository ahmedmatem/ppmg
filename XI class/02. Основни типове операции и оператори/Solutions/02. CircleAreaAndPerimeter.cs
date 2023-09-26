namespace CircleAreaAndPerimeter
{
    internal class CircleAreaAndPerimeter
    {
        static void Main(string[] args)
        {
            // Rerad radius
            double radius = double.Parse(Console.ReadLine());

            // Calculate circle area and perimeter
            double area = Math.PI * radius * radius;
            double perimeter = 2 * Math.PI * radius;

            // Round calculated above area and perimeter 2 digits after floating point
            double roundedArea = Math.Round(area, 2);
            double roundedPerimeter = Math.Round(perimeter, 2);

            // Print result
            Console.WriteLine($"Area = {roundedArea}");
            Console.WriteLine($"Perimeter = {roundedPerimeter}");
        }
    }
}