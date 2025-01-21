

namespace Appliances_Demo
{
    internal abstract class Appliance
    {
        // Abstract methods
        public abstract double GetPowerConsumption();
        public abstract double GetUsageTime();

        // Virtual methods
        public virtual string Operate()
        {
            return $"Operating a {GetType().Name}";
        }
    }
}
