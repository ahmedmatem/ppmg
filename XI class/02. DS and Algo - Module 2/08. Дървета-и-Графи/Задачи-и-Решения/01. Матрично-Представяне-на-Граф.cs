namespace Graph_Matrix_Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Първи и втори връх въведени от конзолата.
            int v1, v2;

            // брой на върховете в графа
            int n = int.Parse(Console.ReadLine());
            // брой на ребрата в графа
            int m = int.Parse(Console.ReadLine());

            List<int>[] graph = new List<int>[n + 1];

            for (int i = 0; i < n + 1; i++)
            {
                graph[i] = new List<int>();
                for (int j = 0; j < n + 1; j++)
                {
                    graph[i].Add(0);
                }
            }

            for (int i = 0; i < m; i++)
            {
                v1 = int.Parse(Console.ReadLine());
                v2 = int.Parse(Console.ReadLine());

                graph[v1][v2] = 1;
                graph[v2][v1] = 1;
            }

            // Отпечатваме представянето на графа във формат:
            // ред(i):колона1 колона2 ... колонаN
            for (int row = 1; row < n + 1; row++)
            {
                Console.Write($"{row}:");
                for (int col = 1; col < n + 1; col++)
                {
                    Console.Write(graph[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
