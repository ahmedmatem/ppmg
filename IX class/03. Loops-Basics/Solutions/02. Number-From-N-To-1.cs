namespace _02._Number_From_N_To_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = N; i >= 1; i--)
            {
                Console.WriteLine(i);
            }
        }
    }
}