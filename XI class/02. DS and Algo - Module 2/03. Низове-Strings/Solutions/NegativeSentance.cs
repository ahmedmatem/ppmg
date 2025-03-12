namespace Denial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine()!;

            if(str.IndexOf("is not") != -1)
            {
                // низът съдържа "is not"
                str = str.Replace("is not", "is");
            }
            else
            {
                // низът не съдържа "is not"
                str = str.Replace("is", "is not");
            }

            Console.WriteLine(str);
        }
    }
}
