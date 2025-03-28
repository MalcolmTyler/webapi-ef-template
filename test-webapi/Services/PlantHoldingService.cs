using test_webapi.DTOs;
using test_webapi.Data.Entities;
using test_webapi.Repositories;

namespace test_webapi.Services
{
    public class PlantHoldingService : IPlantHoldingService
    {
        private readonly IPlantHoldingRepository _repository;

        public PlantHoldingService(IPlantHoldingRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PlantHoldingReadDto>> GetAllHoldingsAsync()
        {
            var holdings = await _repository.GetAllAsync();
            return holdings.Select(MapToReadDto);
        }

        public async Task<PlantHoldingReadDto?> GetHoldingByIdAsync(int id)
        {
            var holding = await _repository.GetByIdAsync(id);
            return holding != null ? MapToReadDto(holding) : null;
        }

        public async Task<IEnumerable<PlantHoldingReadDto>> GetHoldingsByCustomerAsync(int customerId)
        {
            var holdings = await _repository.GetByCustomerAsync(customerId);
            return holdings.Select(MapToReadDto);
        }

        public async Task<IEnumerable<PlantHoldingReadDto>> GetHoldingsByStatusAsync(int statusId)
        {
            var holdings = await _repository.GetByStatusAsync(statusId);
            return holdings.Select(MapToReadDto);
        }

        public async Task<PlantHoldingReadDto> CreateHoldingAsync(PlantHoldingDto holdingDto)
        {
            var holding = new PlantHolding
            {
                CustID = holdingDto.CustID,
                PlantNameID = holdingDto.PlantNameID,
                SerialNumber = holdingDto.SerialNumber,
                StatusID = holdingDto.StatusID,
                SWL = holdingDto.SWL
            };

            var result = await _repository.AddAsync(holding);
            // Reload the entity with navigation properties
            var createdHolding = await _repository.GetByIdAsync(result.HoldingID);
            return MapToReadDto(createdHolding!);
        }

        public async Task<PlantHoldingReadDto> UpdateHoldingAsync(int id, PlantHoldingDto holdingDto)
        {
            var holding = new PlantHolding
            {
                HoldingID = id,
                CustID = holdingDto.CustID,
                PlantNameID = holdingDto.PlantNameID,
                SerialNumber = holdingDto.SerialNumber,
                StatusID = holdingDto.StatusID,
                SWL = holdingDto.SWL
            };

            await _repository.UpdateAsync(holding);
            // Reload the entity with navigation properties to get updated descriptions
            var updatedHolding = await _repository.GetByIdAsync(id);
            return MapToReadDto(updatedHolding!);
        }

        public async Task DeleteHoldingAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private static PlantHoldingReadDto MapToReadDto(PlantHolding holding)
        {
            return new PlantHoldingReadDto
            {
                HoldingID = holding.HoldingID,
                CustID = holding.CustID,
                PlantNameID = holding.PlantNameID,
                SerialNumber = holding.SerialNumber,
                StatusID = holding.StatusID,
                SWL = holding.SWL,
                PlantDescription = holding.Plant?.PlantDescription,
                StatusDescription = holding.Status?.StatusDescription
            };
        }
    }
}