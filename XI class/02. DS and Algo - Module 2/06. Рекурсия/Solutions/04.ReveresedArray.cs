namespace _04.ReversedArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()!
                .Split()
                .Select(int.Parse)
                .ToArray();

            int lastIndex = input.Length - 1;
            Reverse(input, lastIndex);
        }

        static void Reverse(int[] arr, int index)
        {
            if(index == 0)
            {
                Console.Write(arr[index]);
                return;
            }
            Console.Write(arr[index] + " ");
            Reverse(arr, index - 1);
        }
    }
}
