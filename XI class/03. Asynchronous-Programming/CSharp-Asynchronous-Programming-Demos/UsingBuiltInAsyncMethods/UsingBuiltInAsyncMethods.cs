namespace UsingBuiltInAsyncMethods
{
    using System;
    using System.Net.Http;

    class UsingBuiltInAsyncMethods
    {
        static string websiteHtml = null;

        static async void GetWebsiteHtmlAsync(string websiteUrl)
        {
            HttpClient client = new HttpClient();

            websiteHtml = await client.GetStringAsync(websiteUrl);
            Console.WriteLine("Downloaded html");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter URL of website for which to print HTML:");
            string url = Console.ReadLine();

            GetWebsiteHtmlAsync(url);

            while (true)
            {
                Console.WriteLine("What should I do?");
                string userInput = Console.ReadLine();

                if (userInput == "Print")
                {
                    //Console.WriteLine(websiteHtmlTask.Result);
                    if (websiteHtml != null)
                    {
                        Console.WriteLine(websiteHtml);
                    }
                    else
                    {
                        Console.WriteLine("Loading...");
                    }
                }

                else
                {
                    Console.WriteLine("I don't know that command. Try again...");
                }
            }
        }
    }
}
