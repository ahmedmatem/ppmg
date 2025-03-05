namespace String_Intro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()!.Split(' ');

            string result = "";
            for (int i = 0; i < input.Length; i++)
            {
                int len = input[i].Length;
                //result += string.Concat(Enumerable.Repeat(input[i], len));
                for (int c = 0; c < len; c++)
                {
                    result += input[i];
                }
            }
            Console.WriteLine(result);
        }
    }
}
