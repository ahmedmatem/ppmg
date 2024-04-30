namespace _01.Fibonachy_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int position = int.Parse(Console.ReadLine());
            long fibonachyNumber = FibonachyNumberAt(position);
            Console.WriteLine(fibonachyNumber);
        }

        static long FibonachyNumberAt(int pos)
        {
            if(pos == 1 || pos == 2)
            {
                return 1;
            }
            long number = FibonachyNumberAt(pos - 1) + FibonachyNumberAt(pos - 2);
            return number;
        }
    }
}
