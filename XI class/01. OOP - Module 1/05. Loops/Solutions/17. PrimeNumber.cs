namespace IsPrimeNumber
{
    public class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool isPrime = true;

            for (int i = 2; i < number; i++)
            {
                if(number % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if(isPrime)
            {
                Console.WriteLine($"The number {number} is prime.");
            }
            else
            {
                Console.WriteLine($"The number {number} is NOT prime.");
            }
        }
    }
}
