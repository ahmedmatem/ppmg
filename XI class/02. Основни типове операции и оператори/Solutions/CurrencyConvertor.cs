using System;
/*
20
USD
BGN
 * */

namespace CurrencyConvertor
{
    class CurrencyConvertor
    {
        static void Main(string[] args)
        {
            const double EUR = 1.95583;
            const double USD = 1.79549;
            const double GBP = 2.53405;

            // Input
            double amount = double.Parse(Console.ReadLine());
            string fromCurrency = Console.ReadLine();
            string toCurrency = Console.ReadLine();

            double result = 0;

            // BGN --> F
            if(fromCurrency == "BGN")
            {
                if(toCurrency == "USD") // BGN --> USD
                {
                    result = amount / USD;
                }
                else if(toCurrency == "EUR") // BGN --> EUR
                {
                    result = amount / EUR;
                }
                else if(toCurrency == "GBP") // BGN --> GBP
                {
                    result = amount / GBP;
                }
            }
            // F --> BGN
            else if(toCurrency == "BGN")
            {
                if(fromCurrency == "USD") // USD --> BGN
                {
                    result = amount * USD;
                }
                else if (fromCurrency == "EUR") // EUR --> BGN
                {
                    result = amount * EUR;
                }
                else if (fromCurrency == "GBP") // GBP --> BGN
                {
                    result = amount * GBP;
                }
            }
            // EUR --> USD, GBP
            else if( fromCurrency == "EUR")
            {
                if(toCurrency == "USD") // EUR --> USD
                {
                    result = amount * EUR / USD;
                }
                else if(toCurrency == "GBP") // EUR --> GBP
                {
                    result = amount * EUR / GBP;
                }
            }
            // USD --> EUR, GBP
            else if (fromCurrency == "USD")
            {
                if (toCurrency == "EUR") // USD --> EUR
                {
                    result = amount * USD / EUR;
                }
                else if (toCurrency == "GBP") // USD --> GBP
                {
                    result = amount * USD / GBP;
                }
            }
            // GBP --> USD, EUR
            else if (fromCurrency == "GBP")
            {
                if (toCurrency == "USD") // GBP --> USD
                {
                    result = amount * GBP / USD;
                }
                else if (toCurrency == "EUR") // GBP --> EUR
                {
                    result = amount * GBP / EUR;
                }
            }

            Console.WriteLine($"{result:f2} {toCurrency}");
        }
    }
}
