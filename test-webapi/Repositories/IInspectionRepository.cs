using test_webapi.Data.Entities;

namespace test_webapi.Repositories
{
    public interface IInspectionRepository
    {
        Task<IEnumerable<Inspection>> GetAllAsync();
        Task<Inspection?> GetByIdAsync(int id);
        Task<IEnumerable<Inspection>> GetByPlantHoldingAsync(int holdingId);
        Task<Inspection> AddAsync(Inspection inspection);
        Task UpdateAsync(Inspection inspection);
        Task DeleteAsync(int id);
    }
}