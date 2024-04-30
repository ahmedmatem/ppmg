namespace AsyncAwait
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Threading.Tasks;

    class DownloadFile
    {
        const string FileUrl =
            "http://www.introprogramming.info/wp-content/uploads/2013/07/Books/CSharpEn/Fundamentals-of-Computer-Programming-with-CSharp-Nakov-eBook-v2013.pdf";
        
        static void Main()
        {
            var task = DownloadFileAsync(FileUrl, "book.pdf");

            while (true)
            {
                Console.ReadLine();
            }
        }

        static async Task DownloadFileAsync(string url, string fileName)
        {
            Console.WriteLine("Downloading...");

            using (WebClient client = new WebClient())
            {
                await client.DownloadFileTaskAsync(url, fileName);       
            }

            Console.WriteLine("Download successful.");
            Process.Start(fileName);
        }
    }
}
