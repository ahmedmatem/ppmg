namespace _04.WordCounter
{
#nullable disable
    internal class Program
    {
        static void Main(string[] args)
        {
            string sentence = Console.ReadLine();

            string[] words = sentence.Split(' ',StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(words.Length);
        }
    }
}
