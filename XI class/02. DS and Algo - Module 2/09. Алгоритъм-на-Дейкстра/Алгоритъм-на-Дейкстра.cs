using System.ComponentModel;

namespace Shortest_Path_2
{
    public class Program
    {
        private const int INFINITY = 1_000_000;

        static void Main(string[] args)
        {
            int n = 6; // брой върхове в графа
            int root = 1; // наален връх

            // Диаграма на графа
            /* ******************************      
             *            (9)               *
             *       6 ------------ 5       *
             *       / \(2)          \(6)   *
             *      /   \     (11)    \     *
             *      |    3 ----------- 4    *
             * (14) |   /  \          /     *
             *     /   /(9) \ (10)   /      *
             *     | /       \     /(15)    *
             *     |/    (7)  \  /          *
             *     1  --------- 2           *
             ********************************/

            // Представяне на графа, чрез матрица на съседтсво
            int[,] graph = new int[,]
            {
                // 0    1   2   3   4   5   6
                {  0,   0,  0,  0,  0,  0,  0}, // 0
                {  0,   0,  7,  9,  0,  0, 14}, // 1
                {  0,   7,  0, 10, 15,  0,  0}, // 2
                {  0,   9, 10,  0, 11,  0,  2}, // 3
                {  0,   0, 15, 11,  0,  6,  0}, // 4
                {  0,   0,  0,  0,  6,  0,  9}, // 5
                {  0,  14,  0,  2,  0,  9,  0}  // 6
            };
            // Масив, който пази най-краткия път от началото
            // до върха с номер отговарящ на индекса в масива
            int[] distance = new int[n + 1];
            
            int[] parents = DijkstraAlgorithm(n, graph, root, distance);

            PrintPath(parents, distance);
        }
        /// <summary>
        /// Помощен метод, който отпечатва дървото на най-кратките пътища
        /// чрез родителя на всеки връх и разстоянието от началото до
        /// всеки връх.
        /// </summary>
        /// <param name="parents">Масив, в който се записва предходния връх(родител)
        /// на всеки връх на съответния индекс.</param>
        /// <param name="distance">Масив, в който записваме най-краткия път от началото до всеки връх
        /// съответствъващ на индекса в масива.</param>
        private static void PrintPath(int[] parents, int[] distance)
        {
            Console.WriteLine("Node\t\tParent\t\tDistance");
            for (int i = 1; i < parents.Length; i++)
            {
                Console.WriteLine($"{i}:\t\t{parents[i]}\t\t{distance[i]}");
            }
        }

        /// <summary>
        /// Реализация на алгоритъма на Дейкстра за намиране на най-кратък път
        /// от върха root до всички останали пътища в графа.
        /// </summary>
        /// <param name="n">Брой на върховете в графа.</param>
        /// <param name="graph">Граф, в който търсим най-кратките пътища.</param>
        /// <param name="root">Начален връх.</param>
        /// <param name="distance">Масив, в който записваме откритите най-кратки пътища.</param>
        /// <returns>Връща дървото на най-кратките пътища от root до останалите върхове на графа.</returns>
        private static int[] DijkstraAlgorithm(int n, int[,] graph, int root, int[] distance)
        {
            int nextNodeOnShortestPath = 0, minDistance;
            // Масив, в който отбелязваме посетените върхове до които вече имаме 
            // открит най-кратък път.
            bool[] visited = new bool[n + 1];
            // Представяне на покриващото дърво на най-кратките пътища за графа.
            int[] parent = new int[n + 1];

            // Инициализация на разстоянията в графа.
            for (int i = 1; i <= n; i++)
            {
                if (graph[root, i] == 0)
                {
                    distance[i] = INFINITY;
                }
                else
                {
                    distance[i] = graph[i, root];
                }
            }

            for (int i = 1; i <= n; i++)
            {
                parent[i] = 1;
            }

            // Инициализация на наалния връх.
            visited[root] = true;
            parent[root] = 0;
            distance[root] = 0;

            // n-2 на брой премествания към следващия най-близък връх.
            for(int i = 1; i <= n - 2; i++)
            {
                // Търсене на следващия връх от най-краткия път.
                minDistance = INFINITY;
                for(int j = 1; j <= n; j++)
                {
                    // Търсим най близкото разстояние до следващия непосетен връх.
                    if (!visited[j] && minDistance > distance[j])
                    {
                        minDistance = distance[j];
                        nextNodeOnShortestPath = j;
                    }
                }

                // Маркираме го като посетен
                visited[nextNodeOnShortestPath] = true;
                // и за всички негови съседни върхове се опитваме да открием най-краткия път.
                for(int j = 1; j <= n; j++)
                {
                    if (graph[j, nextNodeOnShortestPath] != 0)
                    {
                        if (distance[j] > distance[nextNodeOnShortestPath] + graph[j, nextNodeOnShortestPath])
                        {
                            // Ако открием по-кратък път до съсед на върха до който сме стигнали
                            // обновяваме разстоянието до него с по-малкото открито разстояние
                            // и отбелязваме върха през който сме го достъпили като негов родител(предшественик).
                            distance[j] = distance[nextNodeOnShortestPath] + graph[j, nextNodeOnShortestPath];
                            parent[j] = nextNodeOnShortestPath;
                        }
                    }
                }
            }

            return parent;
        }
    }
}
