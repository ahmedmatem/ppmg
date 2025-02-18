#nullable disable
namespace LIstJoin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> firstList = 
                Console.ReadLine()
                .Split(' ')
                .ToList();

            List<string> secondList =
                Console.ReadLine()
                .Split(' ')
                .ToList();

            int shortListLengtn = Math.Min(firstList.Count, secondList.Count);
            int longListLengtn = Math.Max(firstList.Count, secondList.Count);

            List<string> joinList = new List<string>();

            for(int i = 0; i < shortListLengtn ; i++)
            {
                joinList.Add(firstList[i]);
                joinList.Add(secondList[i]);
            }

            for(int i = shortListLengtn; i < longListLengtn; i++)
            {
                if(firstList.Count > secondList.Count)
                {
                    joinList.Add(firstList[i]);
                }
                else
                {
                    joinList.Add(secondList[i]);
                }
            }

            Console.WriteLine(string.Join("\n", joinList));
        }
    }
}
