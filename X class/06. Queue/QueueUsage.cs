namespace StackAndQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Какво е опашка?
             * Опашката е структура от данни, която има поведение от тип
             * "първи влязъл, първи излиза" - FIFO(First In First Out).
             */

            // дефиниране на опашка (от числа)
            Queue<double> numbers = new Queue<double>();

            // Enqueue() - Добавя елемент в края на опашката
            numbers.Enqueue(21);
            numbers.Enqueue(.25);
            numbers.Enqueue(-1.5);
            numbers.Enqueue(0);

            // Dequeue() - премахва и връща елемента от началото на опашката
            double firstElement = numbers.Dequeue();
            Console.WriteLine(firstElement);            // изход --> 21
            Console.WriteLine(numbers.Dequeue());       // изход --> 0.25

            // Peek() - Връща елементa елемента от началото на опашката, без да го трие
            Console.WriteLine(numbers.Peek());          // изход --> -1.5

            // Count - връща броя на елементите в опашката
            Console.WriteLine(numbers.Count);           // изход --> 2

            // Contains(element) - проверява дали element се среща в опашката
            Console.WriteLine(numbers.Contains(21));    // изход --> False
            Console.WriteLine(numbers.Contains(0));     // изход --> True

            // ToArray() - преобразува опашка в обикновен масив
            double[] numsArr = numbers.ToArray();

            // Clear() - премахва всички елементи
            numbers.Clear();
            Console.WriteLine(numbers.Count); // изход --> 0
        }
    }
}
