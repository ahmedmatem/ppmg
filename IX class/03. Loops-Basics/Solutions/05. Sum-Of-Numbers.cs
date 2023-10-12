namespace _05._Sum_Of_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            // прочитаме броя на събираемите
            int N = int.Parse(Console.ReadLine());

            // завъртаме цикъл равен на броя на събираемите
            for (int i = 0; i < N; i++)
            {
                // четем поредното събираемо и го добавяме към текущата сума
                sum += int.Parse(Console.ReadLine());
            }

            // отпечатваме резултата
            Console.WriteLine(sum);
        }
    }
}