namespace Permutations
{
    /// <summary>
    /// Генериране на всички пермутации от n-елемента чрез РЕКУРСИЯ.
    /// </summary>
    public class Programs
    {
        static void Main(string[] args)
        {
            // n - брой на елементите в пермутацията - 1 2 3 .. n
            int n = int.Parse(Console.ReadLine()!);

            // масив в който пазим елементите на конкретната пермутация
            // започвайки от подредба 1 2 3 . . n
            int[] p = Enumerable.Range(1, n).ToArray();

            PrintPermutation(p, n);
        }

        /// <summary>
        /// Методът последователно вмъква поредния елемент в края, започвайки от първия
        /// и се извиква отново за останалите n - 1 елемента (без последния).
        /// </summary>
        /// <param name="p">Съхранява елементите на пермутацията</param>
        /// <param name="n">Брой на елементите в пермутацията</param>
        static void PrintPermutation(int[] p, int n)
        {
            if(n == 1)
            {
                // При единствен елемент имаме една пермутация и я отпечатваме
                Print(p);
            }
            // Последователно, започвайки от първия елемент
            for (int i = 0; i < n; i++)
            {
                // разменяме поредния i-ти елемент с последния
                Swap(p, i, n - 1);
                // Рекурсивно извикваме метода за останалите n - 1 елемента
                PrintPermutation(p, n - 1);
                // Връщаме i-тия елемент отново на първоначалната му позиция
                Swap(p, i, n - 1);
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
