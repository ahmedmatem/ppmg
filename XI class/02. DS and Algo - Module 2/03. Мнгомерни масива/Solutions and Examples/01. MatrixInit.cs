namespace Array_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Декларация и Инициализация на двумерен масив с 2 реда и 4 колони (2х4)
            int[,] matrix = new int[,] // матрица с размерност 2 х 4
            {
                { 2, 3, 4, 5},  // първи ред
                { 1, 4, 5, 9}   // втори ред
            };

            int rows = matrix.GetLength(0); // връща боя на редовете в матрицата
            int cols = matrix.GetLength(1); // връща броя на колоните в матрицата

            // Отпеччатване на елементите на двумерен масив с размерност - ROWS x COLS
            // ИЗХОД:       2 3 4 5
            //              1 4 5 9
            for(int row = 0; row < rows; row++) // обхождане по редове
            {
                for(int col = 0; col < cols; col++) // обхождане по колони
                {
                    // отпечатване на текущия елемент на масива 
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine(); // прехвърляне на курсора на нов ред
            }
        }
    }
}
