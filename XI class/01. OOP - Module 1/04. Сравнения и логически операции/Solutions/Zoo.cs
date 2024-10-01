namespace Zoo
{
    public class Program
    {
        static void Main(string[] args)
        {
            string animal = Console.ReadLine();

            switch (animal)
            {
                case "dog":
                    Console.WriteLine("mamal");
                    break;
                case "crocodile":
                case "tortoise":
                case "snake":
                    Console.WriteLine("reptail");
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }
        }
    }
}
