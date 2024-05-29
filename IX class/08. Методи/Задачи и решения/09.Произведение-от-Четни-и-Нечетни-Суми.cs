namespace OddsAndEvensProduction
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int evenSum = GetSumOfEvenDigits(input);
            int oddSum = GetSumOfOddDigits(input);
            Console.WriteLine(evenSum * oddSum);
        }

        static int GetSumOfEvenDigits(string text)
        {
            int sum = 0;

            for(int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    int digit = int.Parse(text[i].ToString());
                    if (digit % 2 == 0)
                    {
                        sum += text[i];
                    }
                }
            }

            return sum;
        }

        static int GetSumOfOddDigits(string text)
        {
            int sum = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    int digit = int.Parse(text[i].ToString());
                    if (digit % 2 != 0)
                    {
                        sum += text[i];
                    }
                }
            }

            return sum;
        }
    }
}
