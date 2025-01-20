namespace ElDevices_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ElectronicDevice hp_1 = new Laptop(16, "HP", 0.5);

            List<ElectronicDevice> devices = new List<ElectronicDevice>()
            {
                hp_1,
                new Laptop(8, "ASSUS", 0.7),
                new Smartphone(60, 8, "IPhone 8", 0.2),
                new Smartphone(100, 9, "Samsung", 0.2)
            };

            foreach (ElectronicDevice device in devices)
            {
                Console.WriteLine(device.Operate());
                Console.WriteLine($"Power consumption: {device.GetPowerConsumption()}");
                Console.WriteLine($"Brand: {device.GetBrand()}");
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine();
            }
        }
    }
}
