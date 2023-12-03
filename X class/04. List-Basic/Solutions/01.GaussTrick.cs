namespace GaussTrick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // четем числа от конзолата и ги записваме в списък
            List<int> numbers = Console.ReadLine()
                .Split()            // разделяме ги по интервал
                .Select(int.Parse)  // превръщаме ги в числа
                .ToList();          // записваме ги в списък

            // намираме средата на списъка - индекса на елемента в средата
            int middleindex = numbers.Count / 2;

            // обхождаме списъка от числа до средата му
            for (int i = 0; i < middleindex; i++)
            {
                // добаваме последния елемент от списка към текущото число
                numbers[i] += numbers.Last();
                // след което изтриваме последния елемент (на позиция  lastElementIndex)
                int lastElementIndex = numbers.Count - 1; // 
                numbers.RemoveAt(lastElementIndex);
            }

            // отпечатваме новия списък на един ред с разделите 'интервал'
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}