namespace Bigger_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // прочитаме две цели числа от конзолата
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            // сравняваме двете числа и отпечатваме по-голямото
            if (firstNumber > secondNumber)
            {
                Console.WriteLine(firstNumber);
            }
            else
            {
                Console.WriteLine(secondNumber);
            }
        }
    }
}