namespace _13._FigureArea
{
    public class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            double area = 0;

            switch(figure)
            {
                case "square":
                case "Square":
                case "Circle":
                case "circle":
                    // Expecting one value
                    if(figure == "square" || figure == "Square")
                    {
                        double side = double.Parse(Console.ReadLine());
                        area = side * side;
                    }
                    else if(figure == "circle" || figure == "Circle")
                    {
                        double radius = double.Parse(Console.ReadLine());
                        area = Math.PI * radius * radius;
                    }
                    break;
                case "rectangle":
                case "triangle":
                    // Expecting two values
                    if(figure == "rectangle")
                    {
                        double sideA = double.Parse(Console.ReadLine());
                        double sideB = double.Parse(Console.ReadLine());
                        area = sideA * sideB;
                    }
                    else if(figure == "triangle")
                    {
                        double side = double.Parse(Console.ReadLine());
                        double hight = double.Parse(Console.ReadLine());
                        area = side * hight / 2;
                    }
                    break;
                default:
                    Console.WriteLine("Unknown figure.");
                    break;
            }

            if(area != 0)
            {
                Console.WriteLine($"{area:f3}");
            }
        }
    }
}
