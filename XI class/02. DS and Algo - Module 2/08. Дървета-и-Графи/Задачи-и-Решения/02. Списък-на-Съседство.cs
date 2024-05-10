namespace Graph_Neighbour_Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // брой на върховете (от 1 до n)
            int n = int.Parse(Console.ReadLine());
            // брой на ребрата
            int m = int.Parse(Console.ReadLine());

            // създаваме масив от списъци с числа за представяне на графа
            List<int>[] graph = new List<int>[n + 1];
            // инициализираме списъците в масива (без този на позиция с индекс 0)
            for (int i = 1; i <= n; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 1;i <= n; i++)
            {
                // четем съседите на i-ти връх във формат: v1 v2 vN
                int[] neighbours = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
                graph[i].AddRange(neighbours);
            }

            // печатаме представвянето на графа
            for(int i = 1; i <= n ; i++)
            {
                Console.Write(i + ": ");
                for (int j = 0; j < graph[i].Count; j++)
                {
                    Console.Write(graph[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
