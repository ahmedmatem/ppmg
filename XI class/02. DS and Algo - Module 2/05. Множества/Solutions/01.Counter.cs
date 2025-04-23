namespace _01.Counter
{
#nullable disable
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> dictionary = new Dictionary<double, int>();

            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            foreach (var num in numbers)
            {
                if (dictionary.ContainsKey(num))
                {
                    // yes: true
                    dictionary[num]++;
                }
                else
                {
                    // no: false
                    dictionary.Add(num, 1);
                }
            }

            foreach (var kv in dictionary)
            {
                Console.WriteLine($"{kv.Key} - {kv.Value} times");
            }
        }
    }
}
