namespace WebCrawler
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class HtmlParser
    {
        private const string ImagePattern = "<img.+?src=\"(.+?)\".*?>";
        private const string AnchorPattern = "<a.+?href=\"(.+?)\".*?>";

        private readonly Regex imageRegex;
        private readonly Regex anchorRegex;

        public HtmlParser()
        {
            this.imageRegex = new Regex(ImagePattern);
            this.anchorRegex = new Regex(AnchorPattern);
        }

        public List<string> ParseAnchorTags(string html)
        {
            MatchCollection matchCollection = this.anchorRegex.Matches(html);

            return matchCollection.Cast<Match>()
                .Select(m => m.Groups[1].Value)
                .ToList();
        }

        public List<string> ParseImgTags(string html)
        {
            MatchCollection matchCollection = this.imageRegex.Matches(html);

            return matchCollection.Cast<Match>()
                .Select(m => m.Groups[1].Value)
                .ToList();
        }
    }
}
