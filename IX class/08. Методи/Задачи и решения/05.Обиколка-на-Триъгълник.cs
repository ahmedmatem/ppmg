namespace Triangle_Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Извикване на метода
            int perimeter = TrianglePerimeter(10, 7, 5);
            // Отпечатване на получения периметър
            Console.WriteLine(perimeter);
        }

        // Метод, който изчислява и връща обиколката на тригълник
        // по зададени три страни - sideA, sideB и sideC.
        static int TrianglePerimeter(int sideA, int sideB, int sideC)
        {
            return sideA + sideB + sideC;
        }
    }
}
