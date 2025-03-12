namespace WordCounter
{
    /// <summary>
    /// Да се напише програма, която приема изречение 
    /// и връща броя на думите в него.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            string sentence = Console.ReadLine()!;

            string[] words = sentence.Split(
                new char[] { ' ', ',', '.', '!', '?', ':', '-', ';' },
                StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(words.Length);
        }
    }
}
