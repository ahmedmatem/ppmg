namespace EqualSums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            bool equalSumsFound = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;

                // намираме лявата сума
                for(int j = 0; j < i; j++)
                {
                    leftSum += numbers[j];
                }

                // намираме дясната сума
                for(int k = i + 1; k < numbers.Length; k++)
                {
                    rightSum += numbers[k];
                }

                if(leftSum == rightSum)
                {
                    equalSumsFound = true;
                    Console.WriteLine(i);
                    break;
                }
            }

            if (!equalSumsFound)
            {
                Console.WriteLine("no");
            }
        }
    }
}
