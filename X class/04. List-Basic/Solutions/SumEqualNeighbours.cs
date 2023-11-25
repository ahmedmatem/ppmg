namespace SumEqualNeighbours
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // четем числа от конзолата в списък
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            // обхождаме списъка от пурвия до предпоследния му елемент
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                // проверяваме дали текущото число е равно на следващото
                if (numbers[i] == numbers[i + 1])
                {
                    // добавяме следващото число към текущото
                    numbers[i] += numbers[i + 1];
                    // изтриваме следващото число на позиция i + 1
                    numbers.RemoveAt(i + 1);
                    // започваме обхождането на списъка отначало като присвоим -1 на i
                    i = -1; // при следващо вллизане в цикъла i ще стане 0 заради стъпката i++
                            // и обхождането ще започне отново отначалото на списъка.
                }
            }

            // отпеатваме списъка
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}