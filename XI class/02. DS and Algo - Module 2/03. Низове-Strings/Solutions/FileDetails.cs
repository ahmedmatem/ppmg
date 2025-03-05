namespace FileDetails_v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = Console.ReadLine()!;
            int lastBackSlashIndex = 0;
            string fileName = "";
            if((lastBackSlashIndex = filePath.LastIndexOf(@"\")) == -1)
            {
                fileName = filePath;
            }
            else
            {
                fileName = filePath.Substring(lastBackSlashIndex + 1);
            }
            string[] fileParts = fileName.Split('.');
    
            Console.WriteLine("File name: " + fileParts[0]);
            Console.WriteLine("File extension: " + fileParts[1]);
        }
    }
}
