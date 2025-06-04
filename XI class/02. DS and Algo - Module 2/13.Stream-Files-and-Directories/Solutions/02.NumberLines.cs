namespace NumberLines
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "../../../input.txt";
            string output = "../../../output.txt";

            StreamReader reader = new StreamReader(input);
            StreamWriter writer = new StreamWriter(output);

            using (reader)
            using (writer)
            {
                int lineNumber = 1;

            }
        }
    }
}
