namespace _01.OddLines
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "input.txt";
            string output = "output.txt";

            StreamReader reader = new StreamReader(input);
            StreamWriter writer = new StreamWriter(output);

            using (reader)
            using (writer)
            {
                int lineNumber = 0;
                string? line;
                while((line = reader.ReadLine()) != null)
                {
                    if(lineNumber % 2 == 1) // odd line
                    {
                        writer.WriteLine(line);
                    }
                    lineNumber++;
                }
            }

        }
    }
}
