namespace ParallelForEach
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Threading.Tasks;

    class ImageFlip
    {
        private const int TaskCapacity = 4;

        static void Main()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            NormalFlipImages("imagesToFlip", "flippedImages");
            Console.WriteLine(sw.Elapsed);

            sw.Restart();
            ParallelFlipImages("imagesToFlip", "flippedImages");
            Console.WriteLine(sw.Elapsed);
        }

        private static void NormalFlipImages(string sourceDirectoryPath, string targetDirectoryPath)
        {
            var filesInDirectory = Directory.GetFiles(sourceDirectoryPath);
            foreach (var image in filesInDirectory)
            {
                FlipImage(image, targetDirectoryPath);
            }
        }

        public static void ParallelFlipImages(string sourceDirectoryPath, string targetDirectoryPath)
        {
            var filesInDirectory = Directory.GetFiles(sourceDirectoryPath);

            List<Task> runningTasks = new List<Task>();
            foreach (var currentFile in filesInDirectory)
            {
                if (runningTasks.Count == TaskCapacity)
                {
                    Task.WaitAny(runningTasks.ToArray());
                    runningTasks.RemoveAll(x => x.IsCompleted);
                }

                var task = FlipImageAsync(currentFile, targetDirectoryPath);
                runningTasks.Add(task);
            }

            Task.WaitAll(runningTasks.ToArray());
        }

        static Task FlipImageAsync(string currentFile, string targetDirectoryPath)
        {
            return Task.Run(() => FlipImage(currentFile, targetDirectoryPath));
        }

        static void FlipImage(string currentFile, string targetDirectoryPath)
        {
            string filename = Path.GetFileName(currentFile);

            Bitmap bitmap = new Bitmap(currentFile);

            bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
            bitmap.Save(Path.Combine(targetDirectoryPath, filename));
        }
    }
}
