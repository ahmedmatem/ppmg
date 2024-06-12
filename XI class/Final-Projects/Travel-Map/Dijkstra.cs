
namespace Travel_Map
{
    public class Dijkstra
    {
        private const int INFINITY = 1_000_000;

        public static int[] DijkstraAlgorithm(
            int n, 
            int[,] graph,
            int root,
            int[] distance)
        {
            int nextNodeOnShortestPath = 0, minDistance;

            bool[] visited = new bool[n + 1];
            int[] parent = new int[n + 1];

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
                parent[i] = root;
            }

            visited[root] = true;
            parent[root] = 0;
            distance[root] = 0;

            for (int i = 1; i <= n - 2; i++)
            {
                minDistance = INFINITY;
                for (int j = 1; j <= n; j++)
                {
                    if (!visited[j] && minDistance > distance[j])
                    {
                        minDistance = distance[j];
                        nextNodeOnShortestPath = j;
                    }
                }

                visited[nextNodeOnShortestPath] = true;
                for (int j = 1; j <= n; j++)
                {
                    if (graph[j, nextNodeOnShortestPath] != 0)
                    {
                        if (distance[j] > distance[nextNodeOnShortestPath] + graph[j, nextNodeOnShortestPath])
                        {
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
