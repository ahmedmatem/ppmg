namespace AnimalType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a name of animal.");

            string animal = Console.ReadLine();

            switch (animal)
            {
                case "dog":
                    Console.WriteLine("mammal");
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
