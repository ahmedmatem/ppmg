static double CalculatePerimeter(double a, double b)
{
    return 2 * a + 2 * b;
}

static double CalculateSquare(double w, double h)
{
    return w * h;
}

double width = double.Parse(Console.ReadLine());
double hight = double.Parse(Console.ReadLine());

double perimeter = CalculatePerimeter(width, hight);
double square = CalculateSquare(width, hight);

Console.WriteLine("Rectangle perimeter is: " + perimeter);
Console.WriteLine("Rectangle square is: " + square);


