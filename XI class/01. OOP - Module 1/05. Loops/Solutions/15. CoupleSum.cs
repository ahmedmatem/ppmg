namespace CoupleSum
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            for (int i = 1; i <= m; i++)
            {
                int firstNumber = int.Parse(Console.ReadLine());
                int secondNumber = int.Parse(Console.ReadLine());

                if(firstNumber + secondNumber > n)
                {
                    Console.WriteLine("Bigger number!");
                }
            }
        }
    }
}
