using System.Collections.Generic;
using System.Threading.Tasks;
using test_webapi;
using test_webapi.Entities;

namespace test_webapi.Repositories
{
    public interface ISummaryRepository
    {
        Task<IEnumerable<Summary>> GetSummariesAsync();
        Task<Summary> GetSummaryAsync(int id);
        Task AddSummaryAsync(Summary summary);
        Task UpdateSummaryAsync(Summary summary);
        Task DeleteSummaryAsync(int id);
        Task<bool> SummaryExistsAsync(int id);
    }
}