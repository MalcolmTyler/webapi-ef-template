using test_webapi.DTOs;
using test_webapi.Data.Entities;
using test_webapi.Repositories;

namespace test_webapi.Services
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _repository;

        public StatusService(IStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<StatusDto>> GetAllStatusAsync()
        {
            var Status = await _repository.GetStatusAsync();
            return Status.Select(MapToDto);
        }

        public async Task<StatusDto?> GetStatusByIdAsync(int id)
        {
            var status = await _repository.GetStatusAsync(id);
            return status != null ? MapToDto(status) : null;
        }

        public async Task<StatusDto> CreateStatusAsync(StatusDto statusDto)
        {
            var status = new Status
            {
                StatusDescription = statusDto.StatusDescription
            };

            var result = await _repository.AddStatusAsync(status);
            return MapToDto(result);
        }

        public async Task UpdateStatusAsync(int id, StatusDto statusDto)
        {
            var status = new Status
            {
                StatusID = id,
                StatusDescription = statusDto.StatusDescription
            };

            await _repository.UpdateStatusAsync(status);
        }

        public async Task DeleteStatusAsync(int id)
        {
            await _repository.DeleteStatusAsync(id);
        }

        private static StatusDto MapToDto(Status status)
        {
            return new StatusDto
            {
                StatusID = status.StatusID,
                StatusDescription = status.StatusDescription
            };
        }
    }
}