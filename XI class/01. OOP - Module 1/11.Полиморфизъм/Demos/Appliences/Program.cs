namespace Appliances_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Appliance[] appliences = {
                new Refrigerator(20.5, true, 2, 24),
                new Refrigerator(13.5, false, 1.8, 12),
                new WashingMachine(5, 1100, 2, 0.5)
            };

            foreach (var app in appliences)
            {
                Console.WriteLine(app.Operate());
                Console.WriteLine($"Power consumption: {app.GetPowerConsumption()}");
                Console.WriteLine($"Usage time: {app.GetUsageTime()}");
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
