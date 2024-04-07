
using System.Collections.Generic;
namespace Queue_Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] names = Console.ReadLine()!.Split(' ');
            Queue<string> childrenQueue = new Queue<string>(names);

            int tossCount = int.Parse(Console.ReadLine()!);
            int tossCounter = 0;

            while(childrenQueue.Count > 1)
            {
                tossCounter++;
                string childName = childrenQueue.Dequeue();
                if(tossCounter != tossCount)
                {
                    childrenQueue.Enqueue(childName);
                }
                else
                {
                    Console.WriteLine($"Removed {childName}");
                    tossCounter = 0;
                }
            }

            Console.WriteLine($"Last is {childrenQueue.Peek()}");
        }
    }
}
