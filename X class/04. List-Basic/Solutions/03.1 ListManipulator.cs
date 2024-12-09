namespace ListEdit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }

                string[] lineParts = line.Split(' ');
                switch(lineParts[0])
                {
                    case "Add":
                        int partsToInt = int.Parse(lineParts[1]);
                        list.Add(partsToInt);
                        break;                        
                    case "Remove":
                        int removeNumber = int.Parse(lineParts[1]);
                        list.Remove(removeNumber);
                        break;
                    case "RemoveAt":
                        int index = int.Parse(lineParts[1]);
                        list.RemoveAt(index);
                        break;
                    case "Insert":
                        int insertNumber = int.Parse(lineParts[1]);
                        int insertIndex = int.Parse(lineParts[2]);
                        list.Insert(insertIndex, insertNumber);
                        break;
                }

            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
