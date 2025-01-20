
using System.Text;

namespace ElDevices_Demo
{
    internal class Smartphone : ElectronicDevice
    {
        // Fields
        private int batteryCapacity;
        private int screenSizeInInches;
        private string brand;
        private double powerConsumption;

        public Smartphone(
            int _baterryCapacity,
            int _screenSizeInInches,
            string _brand,
            double _powerConsumption)
        {
            batteryCapacity = _baterryCapacity;
            screenSizeInInches = _screenSizeInInches;
            brand = _brand;
            powerConsumption = _powerConsumption;
        }

        public override string GetBrand()
        {
            return brand;
        }

        public override double GetPowerConsumption()
        {
            return powerConsumption;
        }

        public override string Operate()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Operate());
            sb.AppendLine(" __________________ ");
            sb.AppendLine("|  _________________ |");
            sb.AppendLine("| |                 | |");
            sb.AppendLine("| |    SMARTPHONE   | |");
            sb.AppendLine("| |      SCREEN     | |");
            sb.AppendLine("| |_________________| |");
            sb.AppendLine("|  _____     _____   |");
            sb.AppendLine("| |     |   |     |  |");
            sb.AppendLine("| |_____|   |_____|  |");
            sb.AppendLine("|___________________|");

            return sb.ToString();
        }
    }
}
