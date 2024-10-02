namespace _16._TimePlus15
{
    public class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            // +15 minutes
            int totalMinutes = minutes + 15;

            if(totalMinutes >= 60)
            {
                minutes = totalMinutes - 60;
                hour++;

                if(hour == 24)
                {
                    Console.WriteLine($"0:0{minutes:x2}");
                }
                else
                {
                    Console.WriteLine($"{hour}:{minutes:x2}");
                }
            }
            else
            {
                Console.WriteLine($"{hour}:{(minutes + 15):x2}");
            }
        }
    }
}
