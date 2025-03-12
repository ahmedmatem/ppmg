using System.Text;

namespace MagicName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string allVowels = "AOEIUY";

            string name = Console.ReadLine()!;
            // 1. премахваме интервалите в началото и края
            name = name.Trim();

            // 3. Превръща всички букви в главни
            name = name.ToUpper();

            // 2. Заменяме всички гласни със звездичка
            foreach (var vowel in allVowels)
            {
                name = name.Replace(vowel, '*');
            }
            //name = name.Replace("A", "*");
            //name = name.Replace("E", "*");
            //name = name.Replace("O", "*");
            //name = name.Replace("I", "*");
            //name = name.Replace("U", "*");
            //name = name.Replace("Y", "*");

            Console.WriteLine(name);
        }
    }
}
