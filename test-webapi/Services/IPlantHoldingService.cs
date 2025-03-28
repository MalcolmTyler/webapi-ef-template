using test_webapi.DTOs;

namespace test_webapi.Services
{
    public interface IPlantHoldingService
    {
        Task<IEnumerable<PlantHoldingReadDto>> GetAllHoldingsAsync();
        Task<PlantHoldingReadDto?> GetHoldingByIdAsync(int id);
        Task<IEnumerable<PlantHoldingReadDto>> GetHoldingsByCustomerAsync(int customerId);
        Task<IEnumerable<PlantHoldingReadDto>> GetHoldingsByStatusAsync(int statusId);
        Task<PlantHoldingReadDto> CreateHoldingAsync(PlantHoldingDto holdingDto);
        Task<PlantHoldingReadDto> UpdateHoldingAsync(int id, PlantHoldingDto holdingDto);
        Task DeleteHoldingAsync(int id);
    }
}