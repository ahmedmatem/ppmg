namespace Shapes_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>()
            {
                new Rectangle(20, 3.5),
                new Circle(3.6),
                new Triangle(3, 4, 5, 3),
                new Circle(10),
                new Rectangle(2, 3),
            };

            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape.Draw());
                Console.WriteLine($"Perimeter: {shape.CalculatePerimeter()} Area: {shape.CalculateArea()}");
            }
        }
    }
}
