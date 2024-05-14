namespace _01.List_Of_Edges
{
#nullable disable

    public class Program
    {
        static void Main(string[] args)
        {
            int parent, child;
            // брой на върховете
            int n = int.Parse(Console.ReadLine());
            List<int> parents = new List<int>(n + 1);
            // Инициализираме всеки връх да има родител 0, т.е. е корен
            for (int i = 0; i <= n; i++)
            {
                parents.Add(0);
            }
            // Въвждане на ребрата във вида: родител -- дете, всяко на нов ред
            // Броят на ребрата е n - 1 (с едно по-малко от броя на върховете)
            for (int i = 1; i < n; i++)
            {
                parent = int.Parse(Console.ReadLine());
                child = int.Parse(Console.ReadLine());
                parents[child] = parent;
            }
            // Отпечатваме списък със родителите на всички върхове
            // във формат: връх: родител
            for(int i = 1; i  <= n; i++)
            {
                Console.WriteLine($"{i}: {parents[i]}");
            }
        }
    }
}
