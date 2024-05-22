using System.Reflection.Metadata.Ecma335;
using System.Security;

namespace XFS_Algorithms
{
#nullable disable

    public class Program
    {
        static void Main(string[] args)
        {
            int u, v;
            Console.Write("Enter the number of vertices of the graph: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of edges: ");
            int m = int.Parse(Console.ReadLine());
            Console.Write("Enter the root element to start: ");
            int root = int.Parse(Console.ReadLine());

            List<int>[] graph = new List<int>[n + 1];
            for (int i = 0; i <= n; i++)
            {
                graph[i] = new List<int>();
            }

            Console.WriteLine($"Enter {m} edges each ends on a new line:");
            for (int i = 1; i <= m; i++)
            {
                // both sides of the edge
                u = int.Parse(Console.ReadLine());
                v = int.Parse(Console.ReadLine());
                graph[u].Add(v);
                graph[v].Add(u);
            }

            //var tree = BFS(n, graph, root);
            //var tree = DFS(n, graph, root);

            List<int> tree = new List<int>();
            for (int i = 0; i <= n; i++)
            {
                tree.Add(0);
            }
            bool[] visited = new bool[n + 1];
            DFSRec(graph, tree, visited, root);

            PrintTree(tree);
        }

        static void PrintTree(List<int> tree)
        {
            for (int i = 1; i < tree.Count; i++)
            {
                Console.WriteLine($"vertex[{i} with parent[{tree[i]}]");
            }
        }

        static void DFSRec(List<int>[] graph, List<int> tree, bool[] visited, int root)
        {
            visited[root] = true;
            for (int i = 0; i < graph[root].Count; i++)
            {
                int neighbour = graph[root][i];
                if (!visited[neighbour])
                {
                    tree[neighbour] = root;
                    DFSRec(graph, tree, visited, neighbour);
                }
            }
        }

        static List<int> DFS(int n, List<int>[] graph, int root)
        {
            List<int> parentsTree = new List<int>(n + 1);
            for (int i = 0; i <= n; i++)
            {
                parentsTree.Add(0);
            }
            bool[] visited = new bool[n + 1];
            Stack<int> s = new Stack<int>();

            visited[root] = true;
            s.Push(root);

            while (s.Count > 0)
            {
                int vertex = s.Peek();
                int neighboursCount = graph[vertex].Count;
                if(neighboursCount > 0)
                {
                    int neighbour = graph[vertex][neighboursCount - 1];
                    graph[vertex].RemoveAt(neighboursCount - 1);
                    if (!visited[neighbour])
                    {
                        visited[neighbour] = true;
                        s.Push(neighbour);
                        parentsTree[neighbour] = vertex;
                    }
                }
                else
                {
                    s.Pop();
                }
            }

            return parentsTree;
        }

        static List<int> BFS(int n, List<int>[] graph, int root)
        {
            int vertex, neighbour;
            List<int> parentsTree = new List<int>(n + 1);
            for (int i = 0; i <= n; i++)
            {
                parentsTree.Add(0);
            }
            Queue<int> verticesQueue = new Queue<int>();
            bool[] visited = new bool[n + 1];
            visited[root] = true;
            verticesQueue.Enqueue(root);
            while (verticesQueue.Count > 0)
            {
                vertex = verticesQueue.Dequeue();
                for (int i = 0; i < graph[vertex].Count; i++)
                {
                    neighbour = graph[vertex][i];
                    if (!visited[neighbour])
                    {
                        visited[neighbour] = true;
                        parentsTree[neighbour] = vertex;
                        verticesQueue.Enqueue(neighbour);
                    }
                }
            }
            return parentsTree;
        }
    }
}
