using System;

namespace WorkingDay
{
    class Workday
    {
        static void Main(string[] args)
        {
            //прочитаме ден от седмицата на английски от конзолата
            string dayOfWeek = Console.ReadLine();

            // проверяваме дали е работен ден или не
            if(dayOfWeek == "Monday")
            {
                Console.WriteLine("Working day.");
            }
            else if (dayOfWeek == "Tuesday")
            {
                Console.WriteLine("Working day.");
            }
            else if (dayOfWeek == "Wednesday")
            {
                Console.WriteLine("Working day.");
            }
            else if (dayOfWeek == "Thursday")
            {
                Console.WriteLine("Working day.");
            }
            else if (dayOfWeek == "Friday")
            {
                Console.WriteLine("Working day.");
            }
            else if (dayOfWeek == "Saturday")
            {
                Console.WriteLine("Weekend.");
            }
            else if (dayOfWeek == "Sunday")
            {
                Console.WriteLine("Weekend.");
            }
            else
            {
                Console.WriteLine("Error.");
            }
        }
    }
}
