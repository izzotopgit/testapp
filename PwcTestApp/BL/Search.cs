using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace PwcTestApp.BL
{
    public class Search
    {
        public RequestOps RequestOps;

        public Search(RequestOps requestOps)
        {
            RequestOps = requestOps;
        }

        public async Task<List<string>> Company(string searchString)
        {
            var data = await RequestOps.HttpPost(searchString);
            var document = PrepareDocument(data);

            List<HtmlNode> nodes = document.DocumentNode.Descendants().Where
                (x => x.Name == "strong" && x.Attributes["class"] != null &&
                   x.Attributes["class"].Value.Contains("left")).ToList();

            return nodes.Select(htmlNode => htmlNode.InnerHtml).ToList();
        }

        public Dictionary<string, int> News(List<string> searchStrings, string site)
        {
            var data = RequestOps.HttpGet(site);
            var document = PrepareDocument(data);
            var siteText = document.DocumentNode.OuterHtml;

            return searchStrings.ToDictionary(entry => entry, entry => Regex.Matches(siteText.ToString(), entry.Replace(",", ""), RegexOptions.IgnoreCase).Count);
        }

        private HtmlDocument PrepareDocument(string data)
        {
            data = WebUtility.HtmlDecode(data);
            var document = new HtmlDocument();
            document.LoadHtml(data);
            return document;
        }
    }
}