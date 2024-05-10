namespace Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()!
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Stack<int> numbers = new Stack<int>(input);

            string line = Console.ReadLine()!;

            while(line != "end")
            {
                string[] command = line!.Split(' ');
                switch(command[0].ToLower())
                {
                    case "add":
                        int firstNumber = int.Parse(command[1]);
                        int secNumber = int.Parse(command[2]);
                        numbers.Push(firstNumber);
                        numbers.Push(secNumber);
                        break;
                    case "remove":
                        int n = int.Parse(command[1]);
                        if(n <= numbers.Count)
                        {
                            for(int i = 0; i < n; i++)
                            {
                                numbers.Pop();
                            }
                        }
                        break;
                    default:
                        break;
                }
                line = Console.ReadLine()!;
            }

            int sum = 0;
            while(numbers.Count > 0)
            {
                sum += numbers.Pop();
            }

            Console.WriteLine("Sum: " + sum);
        }
    }
}
