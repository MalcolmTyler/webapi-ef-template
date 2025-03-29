using test_webapi.DTOs;

namespace test_webapi.Services
{
    public interface IInspectionService
    {
        Task<IEnumerable<InspectionReadDto>> GetAllInspectionsAsync();
        Task<InspectionReadDto?> GetInspectionByIdAsync(int id);
        Task<IEnumerable<InspectionReadDto>> GetInspectionsByPlantHoldingAsync(int holdingId);
        Task<InspectionReadDto> CreateInspectionAsync(InspectionDto inspectionDto);
        Task<InspectionReadDto> UpdateInspectionAsync(int id, InspectionDto inspectionDto);
        Task DeleteInspectionAsync(int id);
    }
}