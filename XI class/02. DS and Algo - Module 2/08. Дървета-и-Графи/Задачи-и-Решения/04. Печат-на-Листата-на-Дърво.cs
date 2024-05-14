namespace _02.Tree_Leaves
{
#nullable disable

    public class Program
    {
        static void Main(string[] args)
        {
            // върхове на реброто
            int parent, child;
            // брой върхове на дървото
            int n = int.Parse(Console.ReadLine());
            List<bool> isLeaves = new List<bool>();
            // допускаме, че всички върхове са листа
            for (int i = 0; i <= n; i++)
            {
                isLeaves.Add(true);
            }
            // четем раменете на дървото
            for (int i = 1;i < n; i++)
            {
                // първото ребро е родител
                parent = int.Parse(Console.ReadLine());
                isLeaves[parent] = false;
                // второто е дете
                child = int.Parse(Console.ReadLine());
            }
            // отпечатваме всички листа
            Console.Write("All leaves: ");
            for (int i = 1; i <= n; i++)
            {
                if (isLeaves[i])
                {
                    Console.Write(i + ", ");
                }
            }
            Console.WriteLine();
        }
    }
}
