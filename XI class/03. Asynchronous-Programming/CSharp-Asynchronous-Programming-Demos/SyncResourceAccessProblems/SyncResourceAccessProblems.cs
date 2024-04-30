using System;
using System.Net;

namespace SyncResourceAccessProblems
{
    class SyncResourceAccessProblems
    {
        static string websiteHtml = "";

        static void GetWebsiteHtml(string websiteUrl)
        {
            WebClient client = new WebClient();

            websiteHtml = client.DownloadString(websiteUrl);
        }

        static void Main()
        {
            Console.WriteLine("Enter URL of website for which to print HTML:");
            string url = Console.ReadLine();

            GetWebsiteHtml(url);

            while(true)
            {
                Console.WriteLine("What should I do?");
                string userInput = Console.ReadLine();

                if (userInput == "Print")
                {
                    Console.WriteLine(websiteHtml);
                }

                else
                {
                    Console.WriteLine("I don't know that command. Try again...");
                }
            }
        }
    }
}
