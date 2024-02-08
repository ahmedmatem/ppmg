namespace TopNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            bool isTop = true;
            string topNumbers = string.Empty;

            for(int i = 0; i < numbers.Length - 1; i++)
            {
                isTop = true;
                for(int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] <= numbers[j])
                    {
                        isTop = false;
                        break;
                    }
                }

                if(isTop)
                {
                    topNumbers += numbers[i] + " ";
                }
            }

            // закачаме последния елемент към низа от топ елементи
            topNumbers += numbers[numbers.Length - 1];

            Console.WriteLine(topNumbers);
        }
    }
}
