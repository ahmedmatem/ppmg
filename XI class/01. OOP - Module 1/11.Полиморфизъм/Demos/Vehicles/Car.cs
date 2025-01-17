
using System.Text;

namespace VehicleHierarchy
{
    internal class Car : Vehicle
    {
        // Fields
        private int numberOfDoors;
        private int enginePower;
        private double fuelConsumption;
        private double maxSpeed;

        public Car(
            int _numberOfDoors, 
            int _enginePower,
            double _fuelConsumption,
            double _maxSpeed)
        {
            numberOfDoors = _numberOfDoors;
            enginePower = _enginePower;
            fuelConsumption = _fuelConsumption;
            maxSpeed = _maxSpeed;
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
            builder.AppendLine(base.Drive());
            builder.AppendLine("     ______");
            builder.AppendLine("    /|_||_\\`.__");
            builder.AppendLine("   (   _    _ _\\");
            builder.AppendLine("   =`-(_)--(_)-'");
            builder.AppendLine("   ~~~~~~~~~~~~~~");

            return builder.ToString();
        }
    }
}
