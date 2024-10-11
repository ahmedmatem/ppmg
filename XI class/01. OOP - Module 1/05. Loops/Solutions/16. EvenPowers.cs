namespace EvenPowers
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i <= n; i++)
            {
                if(i % 2 == 0)
                {
                    double pow = Math.Pow(2, i);
                    Console.WriteLine(pow);
                }
                
            }
        }
    }
}
