namespace _02.CharCounters
{
#nullable disable
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Dictionary<char, int> counter = new Dictionary<char, int>();

            foreach (var ch in text)
            {
                if (counter.ContainsKey(ch))
                {
                    // yes
                    counter[ch]++;
                }
                else
                {
                    // no
                    // counter.Add(ch, 1);
                    counter[ch] = 1;
                }
            }

            foreach (var pair in counter)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
