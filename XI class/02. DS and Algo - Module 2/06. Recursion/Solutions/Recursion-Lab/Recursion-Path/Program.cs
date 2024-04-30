namespace Recursion_Path
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Print(10);
        }

        static void Print(int number)
        {
            
            if (number == 1)
            {
                return;
            }
            Console.WriteLine("Before calling Print with " + number);
            Print(number - 1);
            Console.WriteLine("After calling Print with " + number);
        }
    }
}
