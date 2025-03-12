namespace PerfectNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine()!.ToUpper();

            bool isPerfect = true;

            for(int i = 0; i < word.Length - 1; i++)
            {
                if (word.IndexOf(word[i], i + 1) != -1)
                {
                    isPerfect = false;
                    break;
                }
            }

            Console.WriteLine(isPerfect);
        }
    }
}
