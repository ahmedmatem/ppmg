﻿namespace Matrix_Sums
{
    /// <summary>
    /// Задача:
    /// 
    /// Да се намерят и отпечатат сумите от елементите НАД и ПОД ОБРАТНИЯ ДИАГОНАЛ
    /// в дадена КВАДРАТНА матрица (двумерен масив  с равен брой редове и колони).
    /// 
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            // прочитане на размерноста на КВАДРАТНА матрица (равен брой редове и колони)
            int rows = int.Parse(Console.ReadLine()); // брой редове
            int cols = rows; // същият брой колони

            // Деклариране на двумерен масив с размери rows x cols
            int[,] matrix = new int[rows, cols];

            // Инициализация на двумерен масив от конзолата
            // - Обхождане на масива елемент по елемент 
            for(int row = 0; row < rows; row++ ) // за всеки ред
            {
                // Вход от конзолата: 2 13 7 -4 (поредца от числа разделени с интервал)
                // Прочитане и добавяне на числата въведени от конзола в едномерен масив
                int[] numbers = Console.ReadLine()  // четене на ред от конзолата
                    .Split(' ')                     // Сплитване на реда по разделите "интервал"
                    .Select(int.Parse)              // преобразуване на получените стрингове към числа
                    .ToArray();                     // и записването им в едномерен масив

                for(int col = 0; col < cols; col++) // на всяка колона
                {
                    // Попълване на текущия ред на двумерния масив чрез прехвърляне
                    // на елементите на горния масив получен от конзолата в него
                    matrix[row, col] = numbers[col];
                }
            }

            int upSum = 0; // инициализация на сумата НАД обратния диагонал
            int lowSum = 0;// инициализация на сумата ПОД обратния диагонал

            /*
             * Ако сборът от индексите (row+col) на даден елемент в матрицата е по-малък от rows-1
             * (броя на редовет(или колоните) - 1) то този елемент се намира НАД обратния диагонал.
             * Ако сборът от индексите на елемента е по-голям от rows-1 - то той се намира ПОД
             * обратния диагонал.
             */

            // Сума от индексите на елементите образуващи обратния диагонал (reverse diagonal)
            int reverseDiagonalIndexSum = rows - 1;

            // Обхождане елементите на матрицата
            for (int row = 0; row < rows; row++)    // за всеки ред
            {
                for (int col = 0; col < cols; col++)// на всяка колона (елемент в реда)
                {
                    // текущия елемент е matrix[row, col] - проверка дали е НАД или ПОД обратния диагонал
                    if(row + col < reverseDiagonalIndexSum)     // НАД
                    {
                        // добавяме го към горната сума
                        upSum += matrix[row, col];
                    }
                    else if(row + col > reverseDiagonalIndexSum)// ПОД
                    {
                        // добавяме го към долната сума
                        lowSum += matrix[row, col];
                    }
                }
            }

            // Отпечатване на пресметнатите суми
            Console.WriteLine(upSum);
            Console.WriteLine(lowSum);
        }
    }
}
