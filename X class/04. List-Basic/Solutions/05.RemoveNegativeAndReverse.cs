using System.Linq;

namespace RemoveNegativeAndReverse
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

            // Премахваме отрицателните числа и обръщаме списъка

            // Вариант 1
            //numbers.RemoveAll(number => number < 0);

            // Вариант 2
            // Обхождаме списъка и трием елемент ако се окаже отрицателен
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers.RemoveAt(i--);  // връщаме се на предхония елемемт с i--
                                            // след като сме изтрили първо текущия елемент
                }
            }
            numbers.Reverse(); // Обръщаме списъка

            // Отпечатваме списък с положителни числа на обратно
            if (numbers.Count == 0)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}