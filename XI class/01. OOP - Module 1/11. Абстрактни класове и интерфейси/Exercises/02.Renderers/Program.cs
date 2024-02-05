namespace Renderer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../output.txt";
            IRenderer renderer = new ConsoleRenderer();

            IShape[] shapes = new IShape[]
            {
                new Circle(renderer),
                new Text(renderer, "Abstraction"),
                new Square(renderer),
                new Circle(renderer),
            };

            foreach (var shape in shapes)
            {
                shape.Draw();
            }
        }
    }
}
