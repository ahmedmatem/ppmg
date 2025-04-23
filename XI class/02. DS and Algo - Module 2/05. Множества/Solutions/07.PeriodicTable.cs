#nullable disable
namespace _08.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> output = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] chemicals = Console.ReadLine().Split();
                foreach (var chemical in chemicals)
                {
                    output.Add(chemical);
                }
            }

            Console.WriteLine(string.Join(" ", output));
        }
    }
}
