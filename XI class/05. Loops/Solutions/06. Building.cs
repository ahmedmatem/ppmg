using System;

namespace Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int levels = int.Parse(Console.ReadLine()); // 1, 2, ..., levels
            int rooms = int.Parse(Console.ReadLine()); // 0, 1, ..., rooms-1

            int topLevel = levels;

            for (int level = levels; level >= 1; level--)
            {
                for (int room = 0; room < rooms; room++)
                {
                    // {AOL}{level}{room}
                    if(level == topLevel) // roof
                    {
                        Console.Write($"L{level}{room} ");
                    }
                    else if(level % 2 == 0) // even level
                    {
                        Console.Write($"O{level}{room} ");
                    }
                    else
                    {
                        // odd level
                        Console.Write($"A{level}{room} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
