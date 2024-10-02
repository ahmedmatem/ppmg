namespace WorkTimeWithSwitchStatement
{
    public class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            string day = Console.ReadLine();

            switch(day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                case "Saterday":
                    // Working day
                    if(hour >= 10 && hour <= 18)
                    {
                        // It's working time
                        Console.WriteLine("open");
                    }
                    else
                    {
                        Console.WriteLine("closed");
                    }
                    break;
                case "Sunday":
                    // Day Off
                    Console.WriteLine("closed");
                    break;
                default:
                    Console.WriteLine("Invalid day name!");
                    break;
            }
        }
    }
}
