namespace AngleConverter
{
    public class Program
    {
        // Напишете програма, която чете ъгъл в радиани
        // (десетично число) и го преобразува в градуси.
        // Използвайте формулата: градус = радиан * 180 / π.
        // Числото π в C# програми е достъпно чрез Math.PI.

        static void Main(string[] args)
        {
            double rad = double.Parse(Console.ReadLine());
            double deg = rad * 180 / Math.PI;
            Console.WriteLine(deg);
        }
    }
}
