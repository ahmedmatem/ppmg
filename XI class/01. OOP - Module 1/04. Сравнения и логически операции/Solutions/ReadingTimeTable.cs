namespace ReadingTimeTable
{
    public class Program
    {
        static void Main(string[] args)
        {
            int allPages = int.Parse(Console.ReadLine());
            int pagesPerHour = int.Parse(Console.ReadLine());
            int availableDays = int.Parse(Console.ReadLine());

            int totalHours = allPages / pagesPerHour;
            int minPagesPerDay = totalHours / availableDays;

            Console.WriteLine(minPagesPerDay);
        }
    }
}
