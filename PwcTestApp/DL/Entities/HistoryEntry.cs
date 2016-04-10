using System;

namespace PwcTestApp.DL.Entities
{
    public class HistoryEntry
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int CompanyMentions { get; set; }

        public DateTime QueryDateTime { get; set; }
    }
}