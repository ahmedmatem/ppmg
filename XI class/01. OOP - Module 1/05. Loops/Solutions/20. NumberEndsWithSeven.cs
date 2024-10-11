namespace NumbersEndWithSeven
{
    public class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 7; i <= 1000; i += 10)
            //{
            //    Console.WriteLine(i);
            //}
            for (int i = 0; i <= 1000; i++)
            {
                if(i > 9 && i < 100)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
