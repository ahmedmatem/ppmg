namespace Reverse_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> letters = new Stack<char>();

            string input = Console.ReadLine();
            foreach (char ch in input)
            {
                letters.Push(ch);
            }

            while(letters.Count > 0)
            {
                Console.Write(letters.Pop());
            }
        }
    }
}
