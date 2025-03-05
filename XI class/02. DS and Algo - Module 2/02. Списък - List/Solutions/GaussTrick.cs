namespace GaussTrick
{
    internal class Program
    {
        #nullable disable
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int length = nums.Count;

            for (int i = 0; i < length / 2; i++)
            {
                nums[i] += nums[length - 1 - i];
                nums.RemoveAt(nums.Count - 1);
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
