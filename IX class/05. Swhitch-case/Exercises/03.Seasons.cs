namespace Seasons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number in [1..4]");

            int season = int.Parse(Console.ReadLine());

            switch (season)
            {
                case 1:
                    Console.WriteLine("Spring");
                    break;
                case 2:
                    Console.WriteLine("Summer");
                    break;
                case 3:
                    Console.WriteLine("Autumn");
                    break;
                case 4:
                    Console.WriteLine("Winter");
                    break;
                default:
                    Console.WriteLine($"{season} is not in [1..4]");
                    break;
            }

        }
    }
}
