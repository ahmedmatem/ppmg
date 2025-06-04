using System.Text.RegularExpressions;

namespace _05.WordCounter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wordsPath = "../../../Files/words.txt";
            string textPath = "../../../Files/text.txt";
            string outputPath = "../../../Files/output.txt";

            StreamReader wordsReader = new StreamReader(wordsPath);
            StreamReader textReader = new StreamReader(textPath);
            StreamWriter resultWriter = new StreamWriter(outputPath);

            using (wordsReader)
            using (textReader)
            using (resultWriter)
            {
                string text = textReader.ReadToEnd();
                string[] words = wordsReader.ReadLine()!.Split(' ');
                foreach (var word in words)
                {
                    string pattern = "\\b" + word.ToLower() + "\\b";
                    Regex regex = new Regex(pattern);
                    var wordCount = regex.Matches(text.ToLower()).Count;

                    resultWriter.WriteLine(word + " - " + wordCount);
                }
            }
        }
    }
}
