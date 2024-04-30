namespace WebCrawler
{
    using System;
    using System.IO;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    public class Crawler
    {
        private const string DownloadDirectory = "Pics";

        private ConcurrentBag<string> downloadedImages;
        private ConcurrentBag<string> visitedUrls;
        private HtmlParser parser;

        public Crawler()
        {
            this.parser = new HtmlParser();
            this.downloadedImages = new ConcurrentBag<string>();
            this.visitedUrls = new ConcurrentBag<string>();
        }

        public void Crawl(string url, int currentLevel, int maxLevel)
        {
            // Add site to visited
            this.visitedUrls.Add(url);

            // Download Html
            string html = string.Empty;
            using (var client = new WebClient())
            {
                try
                {
                    html = client.DownloadString(url);
                }
                catch (WebException wex)
                {
                    Console.WriteLine(wex.Message);
                }
            }

            // Get all img tags (and their source URL)
            List<string> imgUrls = this.parser.ParseImgTags(html);

            // Download all images from parsed tags
            this.DownloadImages(url, imgUrls);

            // Recursively crawl down anchor URLs until maxLevel is reached
            if (currentLevel <= maxLevel)
            {
                List<string> anchorUrls = this.parser.ParseAnchorTags(html);
                foreach (var anchorUrl in anchorUrls)
                {
                    string address = this.GetValidAddress(url, anchorUrl);
                    if (!this.visitedUrls.Contains(address))
                    {
                        this.Crawl(address, currentLevel + 1, maxLevel);
                    }
                }
            }
        }

        private void DownloadImages(string url, List<string> imgUrls)
        {
            Parallel.ForEach(imgUrls, (imgUrl, loopState) =>
            {
                using (var client = new WebClient())
                {
                    // Generate unique image name to avoid multiple threads writing to same file
                    string fileName = string.Format(
                        "{0}-{1}", Task.CurrentId, this.GetImageName(imgUrl));
                    string address = this.GetValidAddress(url, imgUrl);

                    if (!this.downloadedImages.Contains(address))
                    {
                        try
                        {
                            client.DownloadFile(address, Path.Combine(DownloadDirectory, fileName));
                            this.downloadedImages.Add(address);
                        }
                        catch (WebException wex)
                        {
                            // Console.WriteLine(wex.Message);
                        }
                    }
                }
            });
        }

        private string GetValidAddress(string domainUrl, string subUrl)
        {
            if (subUrl.StartsWith("http"))
            {
                return subUrl;
            }

            return string.Format("{0}/{1}", domainUrl, subUrl);
        }

        private string GetImageName(string imgUrl)
        {
            int lastIndexOfSlash = imgUrl.LastIndexOf("/");
            
            return imgUrl.Substring(lastIndexOfSlash + 1);
        }
    }
}
