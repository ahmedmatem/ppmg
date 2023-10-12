namespace Excellent_Mark_Or_Not
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // прочтаме десетично число от конзолата
            double mark = double.Parse(Console.ReadLine());

            // сравняваме оценката с 5.50
            if (mark >= 5.50)
            {
                // отпечатваме "Excellent!" на конзолата
                Console.WriteLine("Excellent!");
            }
            else
            {
                // отпечатваме "Not xxcellent!" на конзолата
                Console.WriteLine("Not excellent!");
            }
        }
    }
}