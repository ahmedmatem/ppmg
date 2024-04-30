namespace ExceptionsInParallelLoops
{
    using System;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;

    class Program
    {
        private static void ProcessDataInParallel(int[] data)
        {
            var exceptions = new ConcurrentQueue<Exception>();
            Parallel.ForEach(data, dataItem =>
            {
                try
                {
                    if (dataItem < 3)
                        throw new ArgumentException(String.Format("Element values must be > 3", dataItem));
                    else
                        Console.Write(dataItem + " ");
                }
                catch (Exception e) { exceptions.Enqueue(e); }
            });
            if (exceptions.Count > 0) throw new AggregateException(exceptions);
        }


        static void Main(string[] args)
        {
            ProcessDataInParallel(new int[] { 1, 2, 3, 4, 5, 6 });
        }
    }
}
