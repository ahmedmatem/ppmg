namespace _01.ArraySum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()!
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sum = Sum(input, 0);

            Console.WriteLine(sum);
        }

        static int Sum(int[] arr, int index)
        {
            if(index == arr.Length - 1)
            {
                return arr[index];
            }
            return arr[index] + Sum(arr, index + 1);
        }
    }
}
