using System;

namespace Cinema_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string dayOfWeek = Console.ReadLine();

            int price = 0;
            //switch(dayOfWeek)
            //{
            //    case "Monday":
            //    case "Tuesday":
            //    case "Friday":
            //        price = 12;
            //        break;
            //    case "Wednesday":
            //    case "Thursday":
            //        price = 14;
            //        break;
            //    case "Saturday":
            //    case "Sunday":
            //        price = 16;
            //        break;
            //    default:
            //        break;
            //}

            if( dayOfWeek == "Monday" || dayOfWeek == "Tuesday" || dayOfWeek == "Friday")
            {
                // Monday, Tuesday, Friday
                price = 12;
            }
            else if(dayOfWeek == "Wednesday" || dayOfWeek == "Thursday")
            {
                // Wednesday, Thursday
                price = 14;
            }
            else if(dayOfWeek == "Saturday" || dayOfWeek == "Sunday")
            {
                // Weekend
                price = 16;
            }

            Console.WriteLine(price);
        }
    }
}
