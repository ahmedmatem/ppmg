namespace LongestWord
{
    /// <summary>
    /// Напишете програма, която приема изречение 
    /// и извежда най-дългата дума в него. 
    /// Ако има няколко най-дълги думи, да се върне 
    /// първата срещната.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            string sentence = Console.ReadLine()!;

            string[] words = sentence.Split(
                new char[] { ' ', ',', '.', '!', '?', ':', '-', ';', '\'' },
                StringSplitOptions.RemoveEmptyEntries);

            int maxLength = words[0].Length;
            string longestWord = words[0];
            for(int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > maxLength)
                {
                    maxLength = words[i].Length;
                    longestWord = words[i];
                }
            }

            Console.WriteLine(longestWord);
        }
    }
}
