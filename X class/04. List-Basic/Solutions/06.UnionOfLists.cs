namespace UnionOfLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Прочитаме списък от числа на един ред от конзолата
            // Първи списък от числа
            List<int> firstList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            // Втори списък от числа
            List<int> secondList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            // Създаваме празен списък от числа,
            // в който да запишем обединените числа от
            // горните два списъка.
            List<int> unionList = new List<int>();

            // Намираме броя на елементите в по малкия списък от числа
            int minCount = Math.Min(firstList.Count, secondList.Count);

            // Обхождаме двата масива едновременно от 0 до minCount
            for (int i = 0; i < minCount; i++)
            {
                // Добавяме първо елемент от първия списък на текущата позиция,
                unionList.Add(firstList[i]);
                // а после и елемент на същата позиция от втория списък
                unionList.Add(secondList[i]);
            }

            // Проверяваме кой от двата списъка е по дълъг (има повече числа в него)
            // и обхождаме по-дългия от позиция minCount до края, 
            // като добавяме останалите числа в списъка обидинител.
            if(firstList.Count > secondList.Count)
            {
                // Първият списък е по-дълъг
                for (int i = minCount; i <  firstList.Count; i++)
                {
                    unionList.Add(firstList[i]);
                }
            }
            else
            {
                // Втория списък е по-дълъг
                for (int i = minCount; i < secondList.Count; i++)
                {
                    unionList.Add(secondList[i]);
                }
            }

            // Печатаме обединението на двата списъка с интервал между числата
            Console.WriteLine(string.Join(" ", unionList));
        }
    }
}