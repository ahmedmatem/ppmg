using System;

namespace NoThreadSafety
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    class RemovingListElements
    {
        static List<int> numbers;

        static void Main()
        {
            numbers = Enumerable.Range(0, 10000).ToList();

            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < 4; i++)
            {
                Thread thread = new Thread(() => RemoveAllElements());

                threads.Add(thread);
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }
        }

        static void RemoveAllElements()
        {
            while (numbers.Count > 0)
            {
                int lastIndex = numbers.Count - 1;
                numbers.RemoveAt(lastIndex);
            }
        }
    }
}
