namespace _14._WorkTime
{
    public class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            string day = Console.ReadLine();

            if(day == "Sunday")
            {
                // Holiday
                Console.WriteLine("closed");
            }
            else
            {
                // Working day
                if(hour >= 10 && hour <= 18)
                {
                    // Work time
                    Console.WriteLine("open");
                }
                else
                {
                    Console.WriteLine("losed");
                }
            }
        }
    }
}
