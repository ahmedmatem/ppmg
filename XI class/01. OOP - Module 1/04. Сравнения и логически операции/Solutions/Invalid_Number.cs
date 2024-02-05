using System;

namespace Invalid_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            bool isValid = number >= 100 && number <= 200;

            if(!isValid)
            {
                Console.WriteLine("invalid");
            }
        }
    }
}
