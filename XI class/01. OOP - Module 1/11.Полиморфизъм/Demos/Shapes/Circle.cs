
using System.Text;

namespace Shapes_Demo
{
    internal class Circle : Shape
    {
        public double Radius { get; }

        public Circle(double r)
        {
            Radius = r;
        }

        public override double CalculateArea()
        {
            return double.Pi * Radius * Radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * double.Pi * Radius;
        }

        public override string Draw()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.Draw()); // "Drawing Circle"
            builder.AppendLine("    **     ");
            builder.AppendLine(" *      * ");
            builder.AppendLine("*        *");
            builder.AppendLine(" *      * ");
            builder.AppendLine("    **     ");

            return builder.ToString();
        }
    }
}
