namespace Rectangles
{

    /*

2 5 7 2
-3 8 1 3

2 4 10 1
4 3 8 2

0 0 10 8
2 3 8 5

     */
    internal class Program
    {
        static void Main(string[] args)
        {
            // a b c d - 12 2 23 1
            int[] firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();

            // m n p q - 12 2 23 1
            int[] secondLine = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int a = firstLine[0];
            int b = firstLine[1];
            int c = firstLine[2];
            int d = firstLine[3];

            int m = secondLine[0];
            int n = secondLine[1];
            int p = secondLine[2];
            int q = secondLine[3];

            if(a < m && b > n && p < c && q > d)
            {
                Console.WriteLine("2 -> 1");
            }
            else if(m < a && n > b && c < p && d > q)
            {
                Console.WriteLine("1 -> 2");
            }
            else
            {
                Console.WriteLine("No one is inside another.");
            }
        }
    }
}