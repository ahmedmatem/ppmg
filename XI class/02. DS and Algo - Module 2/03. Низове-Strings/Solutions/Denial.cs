#nullable disable
namespace Denial
{
    /// <summary>
    /// Да се напише програма, която чете твърдение(низ)
    /// от потребителя и отпечатва неговото отрицание.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            string sentance = Console.ReadLine();

            if(sentance.IndexOf("is not") == -1)
            {
                // иречението е положително
                sentance = sentance.Replace(" is ", " is not ");
            }
            else
            {
                // изречението е отрицателно
                sentance = sentance.Replace(" is not ", " is ");
            }

            Console.WriteLine(sentance);
        }
    }
}
