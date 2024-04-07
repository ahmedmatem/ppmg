namespace Simple_Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine()!;

            string[] tokens = input.Split(' ');
            Array.Reverse(tokens);

            Stack<string> stack = new Stack<string>(tokens);

            int result = int.Parse(stack.Pop());

            while (stack.Count > 0)
            {
                string operation = stack.Pop();
                switch (operation)
                {
                    case "+":
                        result += int.Parse(stack.Pop());
                        break;
                    case "-":
                        result -= int.Parse(stack.Pop());
                        break;
                    default:
                        Console.WriteLine($"Invalid operation {operation}");
                        Environment.Exit(0);
                        break;
                }
            }

            Console.WriteLine(result);
        }
    }
}
