namespace _03._Number_From_1_To_N_Step_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 1; i <= N; i += 3) 
            {
                Console.WriteLine(i);
            }
        }
    }
}