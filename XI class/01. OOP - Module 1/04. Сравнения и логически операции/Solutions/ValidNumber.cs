namespace _17._ValidNumber
{
    public class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());

            if (number >= 1 && number % 5 == 0)
            {
                Console.WriteLine("Valid!");
            }
            else
            {
                Console.WriteLine("Invalid!");
            }
        }
    }
}
