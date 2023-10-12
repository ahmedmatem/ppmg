namespace Even_Or_Odd_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // прочитаме цяло число от конзолата
            int number = int.Parse(Console.ReadLine());

            // проверяваме числото за четност
            if (number % 2 == 0) // ако е четно
            {
                // отпечатваме, че е четно
                Console.WriteLine("even");
            }
            else
            {
                // отпечатваме, че е нечетно
                Console.WriteLine("odd");
            }
        }
    }
}