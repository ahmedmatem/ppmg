namespace VehicleHierarchy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle[] vehicles = 
                {
                    new Car(4, 120, 0.04, 180),
                    new Motorcycle(1200, true, 0.02, 30),
                    new Motorcycle(60, false, 0.03, 60),
                    new Car(2, 200, 0.06, 380),
                };

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.Drive());
            }
        }
    }
}
