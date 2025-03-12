using System.Text;

namespace TextAlignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()!.Split(' ');

            int maxLength = 0;
            foreach (string word in words)
            {
                if(word.Length > maxLength)
                {
                    maxLength = word.Length;
                }
            }

            
            foreach (var word in words)
            {
                int delta = maxLength - word.Length;
                string tabs = new String(' ', delta);
                Console.WriteLine(tabs + word);
            }
        }
    }
}
