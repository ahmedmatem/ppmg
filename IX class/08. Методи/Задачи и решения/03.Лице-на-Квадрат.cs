namespace Methods_Lab
{
    public class Program
    {
        static void Main(string[] args)
        {
            int side = 5; // страната на фигурата квадрат
            // Извикване на метода SquareArea()
            int area = SquareArea(side);
            // Отпечатване на резултата(лицето)
            Console.WriteLine("The area is " + area);
        }

        // Метод, който намира и връща лицето на квадрат по зададена страна 'а',
        static int SquareArea(int a)
        {
            return a * a;
        }
    }
}
