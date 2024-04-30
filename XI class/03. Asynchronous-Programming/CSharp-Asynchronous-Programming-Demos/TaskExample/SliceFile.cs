using System;
using System.IO;
using System.Threading.Tasks;

class SliceFile
{
    const string VideoPath = "sample_1280x720_surfing_with_audio.mp4";
    const string DestinationPath = "Pieces";
    const int BufferLength = 4096;

    static void Main()
    {
        var task = SliceAsync(VideoPath, DestinationPath, 5);

        Console.WriteLine("Waiting...");
        Console.ReadLine();

        try
        {
            Task.WaitAll(task);
        }
        catch (AggregateException ex)
        {
            Console.WriteLine(ex.Flatten());
        }
    }

    static Task SliceAsync(string sourceFile, string destinationPath, int parts)
    {
        return Task.Run(() =>
        {
            Slice(sourceFile, destinationPath, parts);
        });
    }

    static void Slice(string sourceFile, string destinationPath, int parts)
    {
        if (!Directory.Exists(destinationPath))
        {
            Directory.CreateDirectory(destinationPath);
        }

        using (var source = new FileStream(sourceFile, FileMode.Open))
        {
            FileInfo fileInfo = new FileInfo(sourceFile);
            long partLength = (source.Length / parts) + 1;
            long currentByte = 0;

            for (int currentPart = 1; currentPart <= parts; currentPart++)
            {
                string filePath = string.Format("{0}/Part-{1}.{2}",
                    destinationPath, currentPart, fileInfo.Extension);

                using (var destination = new FileStream(filePath, FileMode.Create))
                {
                    byte[] buffer = new byte[BufferLength];
                    while (currentByte <= partLength * currentPart)
                    {
                        int readBytesCount = source.Read(buffer, 0, buffer.Length);
                        if (readBytesCount == 0)
                        {
                            break;
                        }

                        destination.Write(buffer, 0, readBytesCount);
                        currentByte += readBytesCount;
                    }
                }
            }

            Console.WriteLine("Slice complete.");
        }
    }
}
