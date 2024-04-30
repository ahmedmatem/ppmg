namespace Triangle_Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Извикване на метода(за различни по знак числа)
            PrintSign(23);
            PrintSign(-23);
            PrintSign(0);
        }

        // Метод, който отпечатва дали числото е положително или отрицателно.
        static void PrintSign(int number)
        {
            if(number > 0)
            {
                Console.WriteLine($"The number {number} is positive");
            }
            else if(number < 0)
            {
                Console.WriteLine($"The number {number} is negative");
            }
            else
            {
                Console.WriteLine("The number is neither positive nor negative.");
            }
        }
    }
}
