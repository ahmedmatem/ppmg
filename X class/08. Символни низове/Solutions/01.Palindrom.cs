namespace _01.Palindrom
{
#nullable disable
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var reversedChars = input.ToCharArray();
            Array.Reverse(reversedChars);

            if(input == new string(reversedChars))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
