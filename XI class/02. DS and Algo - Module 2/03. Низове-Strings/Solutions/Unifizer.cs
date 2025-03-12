using System.Text;

namespace Unifizer
{
    /// <summary>
    /// Да се напише програма, която приема като вход низ
    /// и връща нов низ, в който са премахнати всички 
    /// повтарящи се символи.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine()!;
            StringBuilder resultBuilder = new StringBuilder();

            while(input.Length > 1)
            {
                string leftPart = input[0].ToString();
                string rightPart = input.Substring(1);

                input = rightPart.Replace(leftPart, "");
                resultBuilder.Append(leftPart);

            }

            resultBuilder.Append(input);
            Console.WriteLine(resultBuilder);
        }
    }
}
