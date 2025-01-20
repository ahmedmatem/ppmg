
using System.Text;

namespace ElDevices_Demo
{
    internal class Laptop : ElectronicDevice
    {
        // Fields
        private int ramSize;
        private string brand;
        private double powerConsumption;

        public Laptop(int ram, string brand, double powerConsumption)
        {
            ramSize = ram;
            this.brand = brand;
            this.powerConsumption = powerConsumption;
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
            sb.AppendLine("      .__________________________.      ");
            sb.AppendLine("      |  _ _ _ _ _ _ _ _ _ _ __  |      ");
            sb.AppendLine("      | |                      | |      ");
            sb.AppendLine("      | |        LAPTOP        | |      ");
            sb.AppendLine("      | |     SCREEN HERE      | |      ");
            sb.AppendLine("      | |_ _ _ _ _ _ _ _ _ _ _ | |      ");
            sb.AppendLine("      |__________________________|      ");
            sb.AppendLine("       \\#######################/       ");
            sb.AppendLine("        \\####################/        ");
            sb.AppendLine("         \\##################/         ");
            sb.AppendLine("          \\################/          ");
            sb.AppendLine("           \\______________/           ");

            return sb.ToString();
        }
    }
}
