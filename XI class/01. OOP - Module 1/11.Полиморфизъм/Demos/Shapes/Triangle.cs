
using System.Text;

namespace Shapes_Demo
{
    internal class Triangle : Shape
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public double HightA { get; set; }

        public Triangle(double a, double b, double c, double ha)
        {
            SideA = a; 
            SideB = b; 
            SideC = c; 
            HightA = ha;
        }

        public override double CalculateArea()
        {
            return (SideA * HightA) / 2;
        }

        public override double CalculatePerimeter()
        {
            return SideA + SideB + SideC;
        }

        public override string Draw()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.Draw()); // "Drawing Triangle\n"
            builder.AppendLine("      *    ");
            builder.AppendLine("    *   *    ");
            builder.AppendLine("  *       *    ");
            builder.AppendLine(" ***********");

            return builder.ToString();
        }
    }
}
