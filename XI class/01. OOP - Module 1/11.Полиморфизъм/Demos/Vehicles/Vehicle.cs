namespace VehicleHierarchy
{
    internal abstract class Vehicle
    {
        // Abstracts methods
        public abstract double GetMaxSpeed();
        public abstract double GetFuelConsumption();

        // Virtual methods
        public virtual string Drive()
        {
            return $"Driving a {GetType().Name}";
        }
    }
}
