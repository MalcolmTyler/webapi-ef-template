using test_webapi.DTOs;

namespace test_webapi.Services
{
    public interface IPlantHoldingService
    {
        Task<IEnumerable<PlantHoldingDto>> GetAllHoldingsAsync();
        Task<PlantHoldingDto?> GetHoldingByIdAsync(int id);
        Task<IEnumerable<PlantHoldingDto>> GetHoldingsByCustomerAsync(int customerId);
        Task<IEnumerable<PlantHoldingDto>> GetHoldingsByStatusAsync(int statusId);
        Task<PlantHoldingDto> CreateHoldingAsync(PlantHoldingDto holdingDto);
        Task UpdateHoldingAsync(int id, PlantHoldingDto holdingDto);
        Task DeleteHoldingAsync(int id);
    }
}