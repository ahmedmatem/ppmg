using System;
using System.Globalization;

namespace After1000days
{
    class After100Days
    {
        static void Main(string[] args)
        {
            const string DATE_FORMAT = "dd-MM-yyyy";

            // 25-02-1995
            string date = Console.ReadLine();
            DateTime birthdayDate = DateTime.ParseExact(date, DATE_FORMAT, CultureInfo.InvariantCulture);
            DateTime dateAfter100Days = birthdayDate.AddDays(999);

            Console.WriteLine(dateAfter100Days.ToString(DATE_FORMAT));
            Console.WriteLine(DateTime.Now.ToString(DATE_FORMAT));
        }
    }
}
