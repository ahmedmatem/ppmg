
namespace Shapes_Demo
{
    internal abstract class Shape
    {
        public abstract double CalculatePerimeter();
        public abstract double CalculateArea();

        public virtual string Draw()
        {
            // $"Drawing {classType.Name}"
            return $"Drawing {GetType().Name}";
        }
    }
}
