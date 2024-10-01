namespace _07._NuberInRange
{
    public class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            if(number >= -100 && number != 0 && number <= 100)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
