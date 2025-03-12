namespace StringSummary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstWord = Console.ReadLine()!;
            string secondWord = Console.ReadLine()!;

            if(firstWord.Length != secondWord.Length)
            {
                Console.WriteLine("No");
            }
            else
            {
                bool isAnagram = true; // приемаме, че са анаграми
                for(int i = 0; i < firstWord.Length; i++)
                {
                    if (!secondWord.ToLower().Contains(char.ToLower(firstWord[i])))
                    {
                        isAnagram = false;
                        break;
                    }
                }

                if (isAnagram)
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
            }
        }
    }
}
