namespace ElDevices_Demo
{
    internal abstract class ElectronicDevice
    {
        // section: Abstract methods
        public abstract double GetPowerConsumption();
        public abstract string GetBrand();

        // section: Virtual methods
        public virtual string Operate()
        {
            return $"Operating a {GetType().Name}";
        }
    }
}
