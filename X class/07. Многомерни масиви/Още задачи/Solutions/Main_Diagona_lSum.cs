namespace MainDiagonalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // квадратна матрица от числа
            int[,] matrix = new int[,]
            {
                { -1, 12, 3, 0},
                { 6, 1, -1, 7},
                { 5, 11, -3, 4},
                { -1, 17, -8, 10},
            };

            int sum = 0;
            // пресмятане на сумата на елементите по главния диагонал
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }

            Console.WriteLine(sum);
        }
    }
}
