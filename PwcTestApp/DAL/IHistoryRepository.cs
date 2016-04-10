using System.Collections.Generic;
using System.Threading.Tasks;
using PwcTestApp.Models;

namespace PwcTestApp.DAL
{
    public interface IHistoryRepository
    {
        List<HistoryData> GetHistory();
        Task SaveHistoryAsync(Dictionary<string, int> data);
    }
}