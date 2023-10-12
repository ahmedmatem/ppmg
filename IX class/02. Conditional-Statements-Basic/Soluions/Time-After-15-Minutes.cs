namespace Time_After_15_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // четем час и минути от конзолата
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            // добавяме 15 минути
            int minutesAfter15 = minutes + 15;

            // проверяваме дали минутите не надминават 60
            if(minutesAfter15 >= 60)
            {
                // добавяме 1 към часовете
                hours += 1;
                // и изчисляваме остатъка от минутите (след 15) отново
                minutes = minutesAfter15 - 60;

                // но ако часовете са станали повече от 23 (т.е. 24)
                // ги правим 0
                if (hours == 24)
                {
                    hours = 0;
                }
            }

            // отпечатваме новия час (с водеща нула за минути по-малки от 10)
            Console.WriteLine($"{hours}:{minutes:d2}");
        }
    }
}