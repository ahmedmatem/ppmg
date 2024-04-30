namespace Triangle_Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Извикване на метода за изчисляване на лицето на тригълник
            double area = TriangleArea(10, 5);
            // Отпечатване на лицето на триъгълник със страна 10 и височина 5.
            Console.WriteLine(area);
        }

        // Метод, който по зададена страна 'a' и височина към
        // нея 'ha' изчислява и връща лицето на триъгълник.
        static double TriangleArea(double a, double ha)
        {
            return a * ha / 2;
        }
    }
}
