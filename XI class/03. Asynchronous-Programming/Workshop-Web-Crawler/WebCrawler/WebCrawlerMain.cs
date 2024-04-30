namespace WebCrawler
{
    using System;
    using System.Threading.Tasks;

    public class WebCrawlerMain
    {
        private static Crawler crawler;

        static void Main()
        {
            crawler = new Crawler();

            while (true)
            {
                string url = Console.ReadLine();
                RunCrawl(url);
            }
        }

        static async void RunCrawl(string url)
        {
            await Task.Run(() =>
            {
                crawler.Crawl(url, 0, 1);
            });

            Console.WriteLine("{0} has been crawled.", url);
        }
    }
}
