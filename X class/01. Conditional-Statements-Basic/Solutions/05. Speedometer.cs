using System;

namespace Speedometer
{
    class Speedometer
    {
        static void Main(string[] args)
        {
            // прочитаме скоростта от конзолата - дробно число
            double speed = double.Parse(Console.ReadLine());

            // сравняваме скоростта с дадените гранични скорости и печатаме
            if(speed <= 10)
            {
                Console.WriteLine("slow");
            }
            else if(speed <= 50)
            {
                Console.WriteLine("average");
            }
            else if(speed <= 150)
            {
                Console.WriteLine("fast");
            }
            else if(speed <= 1000)
            {
                Console.WriteLine("ultra fast");
            }
            else
            {
                Console.WriteLine("extremely fast");
            }
        }
    }
}
