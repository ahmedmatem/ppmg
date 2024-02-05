namespace RectangleArea
{
    internal class RectangleArea
    {
        static void Main(string[] args)
        {
            // Read the coordinates of opposite vertices
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            // Calculate width and height by coordinates
            double width = Math.Abs(x1 - x2);
            double height = Math.Abs(y1 - y2);

            // Calculate Area and Perimeter
            double area = width * height;
            double perimeter = (width + height) * 2;

            // Print result
            Console.WriteLine(area);
            Console.WriteLine(perimeter);
        }
    }
}