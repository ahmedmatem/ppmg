namespace OldPirateCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 0. Прочитаме съобщението за кодиране
            string message = Console.ReadLine()!;

            // 1. Превръщаме всички букви в малки
            message = message.ToLower();

            // 2.
            // Заменяме а с @
            message = message.Replace('a', '@');

            // Заменяме о с 0
            message = message.Replace('o', '0');

            // Заменяме i с 1
            message = message.Replace('i', '1');

            // Заменяме е с 3
            message = message.Replace('e', '3');

            // 3. Премахваме всички интервали
            message = message.Replace(" ", "");

            // Отпечатваме кодираното съобщение
            Console.WriteLine(message);

        }
    }
}
