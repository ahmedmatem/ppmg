#nullable disable
namespace _07.ContinentsByCountriesAndCities
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var continents = 
                new Dictionary<string, Dictionary<string, HashSet<string>>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string row = Console.ReadLine();
                string[] rowParts = row.Split(' ');
                string continent = rowParts[0];
                string country = rowParts[1];
                string city = rowParts[2];

                if (!continents.ContainsKey(continent))
                {
                    continents[continent] = new Dictionary<string, HashSet<string>>();
                }
                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent][country] = new HashSet<string>();
                }
                continents[continent][country].Add(city);
            }


        }
    }
}
