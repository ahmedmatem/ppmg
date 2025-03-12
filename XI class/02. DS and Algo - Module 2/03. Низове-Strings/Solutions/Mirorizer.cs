namespace Mirorizer
{
    /// <summary>
    /// Напишете програма, която приема низ от потребителя и 
    /// отпечатва неговия огледален образ – низа, 
    /// написан наобратно.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine()!;

            //Console.WriteLine(string.Join("", input.Reverse()));

            // or
            for(int i = input.Length - 1; i >= 0; i--)
            {
                Console.Write(input[i]);
            }

        }
    }
}
