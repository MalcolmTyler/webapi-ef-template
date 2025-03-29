using test_webapi.Data.Entities;
using test_webapi.DTOs;
using test_webapi.Repositories;

namespace test_webapi.Services
{
    public class InspectionService : IInspectionService
    {
        private readonly IInspectionRepository _repository;

        public InspectionService(IInspectionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<InspectionReadDto>> GetAllInspectionsAsync()
        {
            var inspections = await _repository.GetAllAsync();
            return inspections.Select(MapToReadDto);
        }

        public async Task<InspectionReadDto?> GetInspectionByIdAsync(int id)
        {
            var inspection = await _repository.GetByIdAsync(id);
            return inspection != null ? MapToReadDto(inspection) : null;
        }

        public async Task<IEnumerable<InspectionReadDto>> GetInspectionsByPlantHoldingAsync(int holdingId)
        {
            var inspections = await _repository.GetByPlantHoldingAsync(holdingId);
            return inspections.Select(MapToReadDto);
        }

        public async Task<InspectionReadDto> CreateInspectionAsync(InspectionDto inspectionDto)
        {
            var inspection = new Inspection
            {
                HoldingID = inspectionDto.HoldingID,
                InspectionDate = inspectionDto.InspectionDate,
                Location = inspectionDto.Location,
                VehicleInspectedOn = inspectionDto.VehicleInspectedOn,
                RecentCheck = inspectionDto.RecentCheck,
                PreviousCheck = inspectionDto.PreviousCheck,
                SafeWorking = inspectionDto.SafeWorking,
                Defects = inspectionDto.Defects,
                Rectified = inspectionDto.Rectified,
                LatestDate = inspectionDto.LatestDate,
                TestDetails = inspectionDto.TestDetails,
                MiscNotes = inspectionDto.MiscNotes,
                HasSubPlant = inspectionDto.HasSubPlant
            };

            var result = await _repository.AddAsync(inspection);
            var createdInspection = await _repository.GetByIdAsync(result.UniqueRef);
            return MapToReadDto(createdInspection!);
        }

        public async Task<InspectionReadDto> UpdateInspectionAsync(int id, InspectionDto inspectionDto)
        {
            var inspection = new Inspection
            {
                UniqueRef = id,
                HoldingID = inspectionDto.HoldingID,
                InspectionDate = inspectionDto.InspectionDate,
                Location = inspectionDto.Location,
                VehicleInspectedOn = inspectionDto.VehicleInspectedOn,
                RecentCheck = inspectionDto.RecentCheck,
                PreviousCheck = inspectionDto.PreviousCheck,
                SafeWorking = inspectionDto.SafeWorking,
                Defects = inspectionDto.Defects,
                Rectified = inspectionDto.Rectified,
                LatestDate = inspectionDto.LatestDate,
                TestDetails = inspectionDto.TestDetails,
                MiscNotes = inspectionDto.MiscNotes,
                HasSubPlant = inspectionDto.HasSubPlant
            };

            await _repository.UpdateAsync(inspection);
            var updatedInspection = await _repository.GetByIdAsync(id);
            return MapToReadDto(updatedInspection!);
        }

        public async Task DeleteInspectionAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private static InspectionReadDto MapToReadDto(Inspection inspection)
        {
            return new InspectionReadDto
            {
                UniqueRef = inspection.UniqueRef,
                HoldingID = inspection.HoldingID,
                InspectionDate = inspection.InspectionDate,
                Location = inspection.Location,
                VehicleInspectedOn = inspection.VehicleInspectedOn,
                RecentCheck = inspection.RecentCheck,
                PreviousCheck = inspection.PreviousCheck,
                SafeWorking = inspection.SafeWorking,
                Defects = inspection.Defects,
                Rectified = inspection.Rectified,
                LatestDate = inspection.LatestDate,
                TestDetails = inspection.TestDetails,
                MiscNotes = inspection.MiscNotes,
                HasSubPlant = inspection.HasSubPlant,
                PlantDescription = inspection.PlantHolding?.Plant?.PlantDescription,
                SerialNumber = inspection.PlantHolding?.SerialNumber
            };
        }
    }
}