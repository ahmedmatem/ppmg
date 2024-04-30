namespace ParallelFor
{
    using System;
    using System.Threading.Tasks;

    class Program
    {
        static void MultiplyMatricesParallel(double[,] matA, double[,] matB, double[,] result)
        {
            int matACols = matA.GetLength(1);
            int matBCols = matB.GetLength(1);
            int matARows = matA.GetLength(0);

            Parallel.For(0, matARows, row =>
            {
                for (int col = 0; col < matBCols; col++)
                {
                    double currentCellValue = 0;
                    for (int k = 0; k < matACols; k++)
                    {
                        currentCellValue += matA[row, k] * matB[k, col];
                    }
                    result[row, col] = currentCellValue;
                }
            });
        }

        static void Main(string[] args)
        {
            double[,] A = {
                              {1, 0, 0},
                              {0, 1, 0},
                              {0, 0, 1}
                          };
            double[,] B = {
                              {1, 0, 2},
                              {0, 2, 2},
                              {0, 0, 3}
                           };
            double[,] C = new double[3, 3];

            MultiplyMatricesParallel(A, B, C);

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(C[row, col] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
