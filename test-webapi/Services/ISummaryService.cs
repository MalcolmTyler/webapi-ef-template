using System.Collections.Generic;
using System.Threading.Tasks;
using test_webapi;
using test_webapi.DTOs;

namespace test_webapi.Services
{
    public interface ISummaryService
    {
        Task<IEnumerable<SummaryDto>> GetAllSummariesAsync();
        Task<SummaryDto?> GetSummaryByIdAsync(int id);
        Task<SummaryDto> CreateSummaryAsync(SummaryDto summaryDto);
        Task<SummaryDto?> UpdateSummaryAsync(int id, SummaryDto summaryDto);
        Task DeleteSummaryAsync(int id);
    }
}