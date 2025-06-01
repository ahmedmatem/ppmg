namespace _05.RecursiveDrawing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Draw(9);
        }

        static void Draw(int n)
        {
            if(n == 0)
            {
                return;
            }
            string output = new string('*', n);
            Console.WriteLine(output);
            Draw(n - 1);
            output = new string('#', n);
            Console.WriteLine(output);
        }
    }
}
