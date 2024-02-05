namespace Restaurant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Waiter waiter = new Waiter();

            while (true)
            {
                Console.WriteLine("What would you like.");
                string orderName = Console.ReadLine();
                waiter.MakeOrder(orderName);
            }
        }
    }
}
