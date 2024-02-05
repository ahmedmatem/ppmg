namespace VehicleClassHierarchyByAbstraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IVehicle[] vehicles = new IVehicle[]
            {
                new Car("Golf 4", "VW", 2020, 5),
                new Car("147", "Alfa Romeo", 2021, 5),
                new Lorry("720S", "Scania", 2015, 22),
            };

            foreach (var vehicle in vehicles)
            {
                vehicle.DisplayInfo();
            }
        }
    }
}
