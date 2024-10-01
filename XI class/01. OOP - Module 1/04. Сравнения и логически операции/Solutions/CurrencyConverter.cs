namespace CurrencyConverter
{
    public class Program
    {
        // Напишете програма за конвертиране на щатски долари(USD) 
        // в български лева(BGN). Използвайте фиксиран курс между долар 
        // и лев: 1 USD = 1.79549 BGN.

        static void Main(string[] args)
        {
            double usd = double.Parse(Console.ReadLine());
            double lev = usd * 1.79549;
            Console.WriteLine($"{lev:f2} lv.");
        }
    }
}
