namespace WordsConcat
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            while (command != "End")
            {
                string firstWord = Console.ReadLine();
                string secondWord = Console.ReadLine();
                string thirdWord = Console.ReadLine();

                Console.WriteLine(firstWord + secondWord + thirdWord);
                command = Console.ReadLine();
            }
        }
    }
}
