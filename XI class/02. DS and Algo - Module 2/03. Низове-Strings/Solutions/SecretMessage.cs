using System.Text;

namespace SecretMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine()!;

            StringBuilder resultBuilder = new StringBuilder();
            for(int i = 0; i < message.Length; i++)
            {
                if (char.IsUpper(message[i]) && i != 0)
                {
                    resultBuilder.Append($" {message[i]}");
                }
                else
                {
                    resultBuilder.Append(message[i]);
                }
            }

            Console.WriteLine(resultBuilder);
        }
    }
}
