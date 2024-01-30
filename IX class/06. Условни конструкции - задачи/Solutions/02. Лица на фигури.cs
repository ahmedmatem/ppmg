namespace FiguresArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            if(figure == "square")
            {
                double side = double.Parse(Console.ReadLine());
                // area = side * side
                double area = side * side;
                Console.WriteLine($"{area:f3}");
            }
            else if(figure == "rectangle")
            {
                double sideA = double.Parse(Console.ReadLine());
                double sideB = double.Parse(Console.ReadLine());
                // area = sideA * sideB
                double area = sideA * sideB;
                Console.WriteLine($"{area:f3}");
            }
            else if(figure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                // area = pi * radius * radius
                double area = Math.PI * radius * radius;
                Console.WriteLine($"{area:f3}");
            }
            else if(figure == "triangle")
            {
                double side = double.Parse(Console.ReadLine());
                double hight = double.Parse(Console.ReadLine());
                // area = side * hight / 2
                double area = side * hight / 2;
                Console.WriteLine($"{area:f3}");
            }
            else
            {
                Console.WriteLine("Invalid fugure.");
            }
        }
    }
}
