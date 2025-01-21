using System.Text;

namespace Appliances_Demo
{
    internal class Refrigerator : Appliance
    {
        // Fields
        private double capacity;
        private bool hasFreezer;
        private double powerConsumption;
        private double usageTime;

        // Construcyor for initialization
        public Refrigerator(
            double _capacity, 
            bool _hasFreezer,
            double _powerConsumption,
            double _usageTime)
        {
            capacity = _capacity;
            hasFreezer = _hasFreezer;
            powerConsumption = _powerConsumption;
            usageTime = _usageTime;
        }

        public override double GetPowerConsumption()
        {
            return powerConsumption;
        }

        public override double GetUsageTime()
        {
            return usageTime;
        }

        public override string Operate()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Operate());
            if(hasFreezer)
            {
                sb.AppendLine($"I have a freezer.");
            }
            else
            {
                sb.AppendLine($"I have no a freezer.");
            }

            return sb.ToString();
        }
    }
}
