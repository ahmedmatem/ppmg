
using System.Text;

namespace Appliances_Demo
{
    internal class WashingMachine : Appliance
    {
        // fields
        private double drumSize;
        private int spinSpeed;
        private double powerConsumption;
        private double usageTime;

        // Constructor for field initialization
        public WashingMachine(
            double _drumSize, // 12 kg
            int _spinSpeed, // 1600 r/m
            double _powerConsumption,// 2 KW
            double _usageTime)// 1.5 hours
        {
            drumSize = _drumSize;
            spinSpeed = _spinSpeed;
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
            sb.AppendLine($"The washing will finish after {usageTime} hours.");

            return sb.ToString();
        }
    }
}
