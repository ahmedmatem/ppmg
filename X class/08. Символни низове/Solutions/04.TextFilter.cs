namespace _06.TextFilter
{
#nullable disable
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Read the banned words
            string[] bannedWords = Console.ReadLine()
                //.Split(',', ' ', StringSplitOptions.RemoveEmptyEntries)
                .Split(", ");

            // 2. Read a text
            string text = Console.ReadLine();

            // 3. Replace each banned word with '****'
            foreach (var banWord in bannedWords)
            {
                string replacement = new string('*', banWord.Length);
                text = text.Replace(banWord, replacement);
            }

            Console.WriteLine(text);
        }
    }
}
