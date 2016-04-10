using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace PwcTestApp.BL
{
    public class RequestOps
    {
        public async Task<string> HttpPost(string company)
        {
            WebRequest req = WebRequest.Create($"https://or.justice.cz/ias/ui/rejstrik-$firma?jenPlatne=PLATNE&nazev={HttpUtility.UrlEncode(company)}&polozek=50&typHledani=STARTS_WITH");

            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";

            WebResponse res = await req.GetResponseAsync();
            StreamReader sr = new StreamReader(res.GetResponseStream());
            string returnvalue = sr.ReadToEnd();

            return returnvalue;
        }

        public string HttpGet(string url)
        {
            WebRequest req = WebRequest.Create(url);

            req.Method = "GET";

            WebResponse res = req.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream());
            string returnvalue = sr.ReadToEnd();

            return returnvalue;
        }
    }
}