using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PwcTestApp.BL
{
    public static class ProcessData
    {
        public static async Task<Dictionary<string, int>> Run(string searchString)
        {
            var search = new Search(new RequestOps());
            var founded = await search.Company(searchString);

            var sites = new List<string>
            {
                "http://www.idnes.cz/",
                "http://regiony.impuls.cz/",
                "http://www.aktualne.cz/",
                "http://www.denik.cz/"
            };

            var aggregatedData = new List<Dictionary<string,int>>();

            Parallel.ForEach(sites, site =>
            {
                aggregatedData.Add(search.News(founded, site));
            });

            var result = aggregatedData.SelectMany(dict => dict)
                         .ToLookup(pair => pair.Key, pair => pair.Value)
                         .ToDictionary(group => group.Key, group => group.First());

            return result;
        }
    }
}