using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelForLocalVariablesCalculatingSubsetSums
{
    class Program
    {
        static void Main(string[] args)
        {
            //Note: This demo should be run in Release mode. In Debug the framework keeps debug information, which slows the parallel processing significantly

            int[] nums = Enumerable.Range(0, 9999 * 100).ToArray();
            long total = 0;

            DateTime start = DateTime.Now;

            double pieceSize = nums.Length / (double)Environment.ProcessorCount;

            
            List<Tuple<int, int>> ranges = new List<Tuple<int, int>>();
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                int rangeStart = (int)Math.Round(i * pieceSize);
                int rangeEnd = (int)Math.Round((i + 1) * pieceSize);
                ranges.Add(new Tuple<int, int>(rangeStart, rangeEnd));
            }

            Parallel.For<long>(0, ranges.Count, () => 0, (rangeInd, loopState, subrangeTotal) =>
            {
                for (int elementInd = ranges[rangeInd].Item1; 
                    elementInd < ranges[rangeInd].Item2; 
                    elementInd++)
                {
                    subrangeTotal += nums[elementInd];
                }

                return subrangeTotal;
            },
            (subrangeSum) => Interlocked.Add(ref total, subrangeSum));

            DateTime end = DateTime.Now;

            Console.WriteLine("time (ms): " + (end - start).Milliseconds);

            Console.WriteLine(total);


            total = 0;
            start = DateTime.Now;
            for (int i = 0; i < nums.Length; i++)
            {
                total += nums[i];
            }
            end = DateTime.Now;

            Console.WriteLine("time (ms): " + (end - start).Milliseconds);

            Console.WriteLine(total);
        }
    }
}
