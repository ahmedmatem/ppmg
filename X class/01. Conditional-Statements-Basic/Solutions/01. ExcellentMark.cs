namespace ExcellentMark
{
    internal class ExcellentMark
    {
        static void Main(string[] args)
        {
            // Read mark
            double mark = double.Parse(Console.ReadLine());

            if (mark >= 5.50)
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}