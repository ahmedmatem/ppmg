#nullable disable
namespace EqualNeighbour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < ints.Count - 1; i++)
            {
                if (ints[i] == ints[i + 1])
                {
                    ints[i] *= 2;
                    ints.RemoveAt(i + 1);
                    i = -1;
                }
            }

            Console.WriteLine(string.Join(' ', ints));
        }
    }
}
