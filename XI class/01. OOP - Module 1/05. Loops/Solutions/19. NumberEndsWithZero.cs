namespace NumberEndsZero
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            while(n % 10 != 0)
            {
                Console.WriteLine("Invalid number!");
                n = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"Thre number is: {n}");
        }
    }
}
