namespace MaxSumSquare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[,]
            {
                { -1, 12, 3, 0, 20, 40 },
                { 6, 1, -1, 7, 7, -10 },
                { 5, 11, -3, -4, 5, 0},
                { -1, 17, -8, 10, 5, -2}
            };

            int maxSum = matrix[0, 0] + matrix[0, 1] + matrix[1, 0] + matrix[1, 1];
            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int sum = matrix[row, col] + 
                        matrix[row, col + 1] + 
                        matrix[row + 1, col] +
                        matrix[row + 1, col + 1];

                    if(sum > maxSum)
                    {
                        maxSum = sum;
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            // MaxSum = 123, position[2, 3]
            Console.WriteLine($"MaxSum = {maxSum}, position[{startRow}, {startCol}]");
        }
    }
}
