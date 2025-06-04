namespace _04.FolderSize
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string testFolder = "../../../TestFolder";
            string output = "../../../output.txt";
            long totalSize = 0;

            StreamWriter writer = new StreamWriter(output);
            string[] files = Directory.GetFiles(testFolder);
            foreach (string file in files)
            {
                var fileInfo = new FileInfo(file);
                totalSize += fileInfo.Length;
            }

            using (writer)
            {
                writer.WriteLine(totalSize / 1024.0 + " KB");
            }
        }
    }
}
