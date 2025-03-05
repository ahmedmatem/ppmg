#nullable disable
namespace TextFilter_v1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] forbiddentWords = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            foreach (var fw in forbiddentWords)
            {
                string replacement = "";
                for (int i = 0; i < fw.Length; i++)
                {
                    replacement += "*";
                }
                text = text.Replace(fw, replacement);
            }

            Console.WriteLine(text);
        }
    }
}
