
using System.Text;

namespace VehicleHierarchy
{
    internal class Motorcycle : Vehicle
    {
        // Fields
        private int engineCapacity;
        private bool hasSidecar;
        private double fuelConsumption;
        private double maxSpeed;

        // Constructor
        public Motorcycle(
            int engineCapacity,
            bool hasSidecar,
            double fuelConsumption,
            double maxSpeed)
        {
            this.engineCapacity = engineCapacity;
            this.hasSidecar = hasSidecar;
            this.fuelConsumption = fuelConsumption;
            this.maxSpeed = maxSpeed;
        }

        public override double GetFuelConsumption()
        {
            return fuelConsumption;
        }

        public override double GetMaxSpeed()
        {
            return maxSpeed;
        }

        public override string Drive()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.Drive()); // "Driving a Motorcycle\n"
            builder.AppendLine("       __o"); 
            builder.AppendLine("     _ \\<,_");
            builder.AppendLine("    (*)/ (*)");
            builder.AppendLine("   ~~~~~~~~~~~~~~");

            return builder.ToString();
        }
    }
}
