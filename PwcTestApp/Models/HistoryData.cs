using System;

namespace PwcTestApp.Models
{
    public class HistoryData
    {
        public string CompanyName { get; set; }
        public int CompanyMentions { get; set; }

        public DateTime QueryDateTime { get; set; }
    }
}