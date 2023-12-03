namespace ListManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // четем числа от един ред на конзолата
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            
            while(true) // безкраен цикъл
                        // в който четем команди от конзолата 

            {
                string command = Console.ReadLine();

                if(command == "end") // ако командата е "end"
                {
                    break; // излизаме от тялото на цикъла
                }

                // Ако командата е различна от "end"
                // Сплитваме командата по интервал
                string[] token = command.Split();
                string commandName = token[0]; // вземаме името на командата

                switch(commandName)
                {
                    case "Add":
                        int addNumber = int.Parse(token[1]);
                        numbers.Add(addNumber);
                        break;
                    case "Remove":
                        int removeNumber = int.Parse(token[1]);
                        numbers.Remove(removeNumber);
                        break;
                    case "RemoveAt":
                        int removeIndex = int.Parse(token[1]);
                        numbers.RemoveAt(removeIndex);
                        break;
                    case "Insert":
                        int insertNumber = int.Parse(token[1]);
                        int insertIndex = int.Parse(token[2]);
                        numbers.Insert(insertIndex, insertNumber);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}