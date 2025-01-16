
using System.Text;

namespace Shapes_Demo
{
    internal class Rectangle : Shape
    {
        public double Width { get; }
        public double Hight { get; }

        public Rectangle(double w, double h)
        {
            Width = w;
            Hight = h;
        }

        public override double CalculateArea()
        {
            return Width * Hight;
        }

        public override double CalculatePerimeter()
        {
            return (Width + Hight) * 2;
        }

        public override string Draw()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.Draw()); // "Drawing Rectangle\n"
            builder.AppendLine(" ------------------");
            builder.AppendLine("|                 |");
            builder.AppendLine("|                 |");
            builder.AppendLine("|                 |");
            builder.AppendLine(" ------------------");
            return builder.ToString();
        }
    }
}
