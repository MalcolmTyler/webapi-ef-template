using test_webapi.DTOs;

namespace test_webapi.Services
{
    public interface IAllPlantService
    {
        Task<IEnumerable<AllPlantDto>> GetAllPlantsAsync();
        Task<AllPlantDto?> GetPlantByIdAsync(int id);
        Task<IEnumerable<AllPlantDto>> GetPlantsByCategoryAsync(int categoryId);
        Task<AllPlantDto> CreatePlantAsync(AllPlantDto plantDto);
        Task UpdatePlantAsync(int id, AllPlantDto plantDto);
        Task DeletePlantAsync(int id);
    }
}