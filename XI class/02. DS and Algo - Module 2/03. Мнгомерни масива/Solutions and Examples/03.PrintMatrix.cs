#nullable disable
namespace PrintMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            int sum = 0;
            for(int row = 0; row < n; row++)
            {
                for(int col = 0; col < n; col++)
                {
                    matrix[row, col] = int.Parse(Console.ReadLine());
                    sum += matrix[row, col];
                }
            }

            // Print matrix rows
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }

            // Print the matrix sum
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
