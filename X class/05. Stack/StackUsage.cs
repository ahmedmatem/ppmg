namespace StackAndQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Какво е стек?
             * Стекът е структура от данни, която има поведение от тип
             * "последен влязъл, първи излиза" - LIFO(Last In First Out).
             * Затова можа да добавяме и извличаме елемент само от "най-горния" край.
             */

            // дефиниране на стек (от низове)
            Stack<string> words = new Stack<string>();

            // Push() - Добавя елемент най-отгоре в стека
            words.Push("bread");
            words.Push("ball");
            words.Push("mouse");
            words.Push("cat");

            // Pop() - премахва и връща най-горния елемент в стека
            string lastElement = words.Pop();
            Console.WriteLine(lastElement);             // изход --> cat
            Console.WriteLine(words.Pop());             // изход --> mouse

            // Peek() - Връща най-горния елемент в стека, без да го премахва
            Console.WriteLine(words.Peek());            // изход --> ball

            // Count - връща броя на елементите в стека
            Console.WriteLine(words.Count);             // изход --> 2

            // Contains(element) - проверява дали element се среща в стека
            Console.WriteLine(words.Contains("lion"));  // изход --> False
            Console.WriteLine(words.Contains("ball"));  // изход --> True

            // ToArray() - преобразува стека в обикновен масив
            string[] wordsArr = words.ToArray();

            // Clear() - премахва всички елементи
            words.Clear();
            Console.WriteLine(words.Count);             // изход --> 0
        }
    }
}
