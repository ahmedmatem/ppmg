using System.Reflection.Metadata.Ecma335;

namespace SumSeconds
{
    public static class Extensions{
        public static string Blabla(this string str, string a)
        {
            return str.ToLower() + a;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int sec1 = int.Parse(Console.ReadLine());
            int sec2 = int.Parse(Console.ReadLine());
            int sec3 = int.Parse(Console.ReadLine());

            int sumInSeconds = sec1 + sec2 + sec3;

            int minutes = sumInSeconds / 60;
            int seconds = sumInSeconds % 60;

            //string delimiter = (seconds < 10) ? ":0" : ":";

            Console.WriteLine($"{minutes}:{seconds:D10}");
        }
    }
}