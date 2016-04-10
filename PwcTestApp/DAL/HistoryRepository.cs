using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PwcTestApp.BL;
using PwcTestApp.DL;
using PwcTestApp.DL.Entities;
using PwcTestApp.Models;

namespace PwcTestApp.DAL
{
    public class HistoryRepository : IHistoryRepository
    {
        public async Task SaveHistoryAsync(Dictionary<string, int> data)
        {

            var date = DateTime.Now;

            using (var db = new DatabaseContext())
            {
                foreach (var item in data)
                {
                    db.HistoryEntries.Add(new HistoryEntry
                    {
                        CompanyName = item.Key,
                        CompanyMentions = item.Value,
                        QueryDateTime = date
                    });
                }
                await db.SaveChangesAsync();
            }
        }

        public List<HistoryData> GetHistory()
        {
            var data = new List<HistoryData>();

            using (var db = new DatabaseContext())
            {
                var dbdata = db.HistoryEntries;

                data.AddRange(dbdata.Select(historyEntry => new HistoryData
                {
                    CompanyName = historyEntry.CompanyName,
                    CompanyMentions = historyEntry.CompanyMentions,
                    QueryDateTime = historyEntry.QueryDateTime
                }));
            }

            return data;
        }
    }
}