namespace Permutations
{
    /// <summary>
    /// Генериране на всички пермутации от n-елемента чрез ИТЕРАЦИИ.
    /// </summary>
    public class Programs
    {
        static void Main(string[] args)
        {
            // n - брой на елементите в пермутацията - 1 2 3 .. n
            int n = int.Parse(Console.ReadLine()!);

            // масив в който пазим елементите на конкретната пермутация
            // начална инециализация - 1 2 3 . . n
            int[] p = Enumerable.Range(1, n).ToArray();

            PrintPermutation(p, n);
        }


        static void PrintPermutation(int[] p, int n)
        {
            while (true)
            {
                // Отпечатваме поредната пермутация
                Print(p);

                // Търсим първия елемент на позиция i от дясно наляво (започвайки от края)
                // по-малък от следващия - p[i] < p[i+1]
                int i = n - 2;
                while (i > -1 && p[i] > p[i + 1])
                {
                    i--;
                }
                if (i == -1)
                {
                    // Такъв елемент на позиция i не е намерен
                    break; // напускаме цикъла
                }

                // Елемент на позиция i такъв, че p[i] < p[i+1] е намерен.

                // Разменяме местата на елемента на позиция i с елемента на позичция j
                // ,където p[j] е най-малкият елемент сред елементите след позиция i до края
                // по-голям от p[i] - т.е. p[j] = min{p[i+1], ... ,p[n-1]}, p[j]>p[i]
                int minPos = i + 1;
                for (int j = i + 2; j < n; j++)
                {
                    if (p[j] < p[minPos] && p[j] > p[i])
                    {
                        minPos = j;
                    }
                }
                Swap(p, i, minPos);

                // Накрая обръщаме последователноста на елементите от позиция i+1 до края
                for (int j = 1; j <= (n - i) / 2; j++)
                {
                    Swap(p, i + j, n - j);
                }
            }
        }

        /// <summary>
        /// Отпечатва елементите на масив във формат - {1,2,3,..,n}
        /// </summary>
        /// <param name="p"></param>
        static void Print(int[] p)
        {
            Console.WriteLine("{" + string.Join(",", p) + "}");
        }

        /// <summary>
        /// Разменя стойностите на елементите на позиции i и j в масива а.
        /// </summary>
        /// <param name="a">Масив, в който се случва размяната</param>
        /// <param name="i">Позиция на елемента за размяна.</param>
        /// <param name="j">Позиция на елемента за размяна.</param>
        static void Swap(int[] a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}
