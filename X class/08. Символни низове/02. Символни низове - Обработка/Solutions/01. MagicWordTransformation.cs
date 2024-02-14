namespace MagicallyChangedWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            bool isMagic = true;

            if (input[0].Length != input[1].Length)
            {
                isMagic = false;
            }
            else
            {
                for(int p = 0; p < input[0].Length; p++)
                {
                    int index = input[0].IndexOf(input[0][p], p + 1);
                    while(index != -1)
                    {
                        if (input[1][index] != input[1][p])
                        {
                            isMagic = false;
                            break;
                        }
                        index = input[0].IndexOf(input[0][p], index + 1);
                    }

                    if(!isMagic)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(isMagic);
        }
    }
}
