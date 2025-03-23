using test_webapi.Data.Entities;
using test_webapi.DTOs;
using test_webapi.Repositories;

namespace test_webapi.Services
{
    public class AllPlantService : IAllPlantService
    {
        private readonly IAllPlantRepository _repository;

        public AllPlantService(IAllPlantRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AllPlantDto>> GetAllPlantsAsync()
        {
            var plants = await _repository.GetAllAsync();
            return plants.Select(MapToDto);
        }

        public async Task<AllPlantDto?> GetPlantByIdAsync(int id)
        {
            var plant = await _repository.GetByIdAsync(id);
            return plant == null ? null : MapToDto(plant);
        }

        public async Task<IEnumerable<AllPlantDto>> GetPlantsByCategoryAsync(int categoryId)
        {
            var plants = await _repository.GetByCategoryAsync(categoryId);
            return plants.Select(MapToDto);
        }

        public async Task<AllPlantDto> CreatePlantAsync(AllPlantDto plantDto)
        {
            var plant = new AllPlantEntity
            {
                PlantDescription = plantDto.PlantDescription,
                PlantCategory = plantDto.PlantCategory,
                NormalPrice = plantDto.NormalPrice
            };

            var result = await _repository.AddAsync(plant);
            return MapToDto(result);
        }

        public async Task UpdatePlantAsync(int id, AllPlantDto plantDto)
        {
            var plant = new AllPlantEntity
            {
                PlantNameID = id,
                PlantDescription = plantDto.PlantDescription,
                PlantCategory = plantDto.PlantCategory,
                NormalPrice = plantDto.NormalPrice
            };

            await _repository.UpdateAsync(plant);
        }

        public async Task DeletePlantAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private static AllPlantDto MapToDto(AllPlantEntity plant)
        {
            return new AllPlantDto
            {
                PlantNameID = plant.PlantNameID,
                PlantCategory = plant.PlantCategory,
                PlantDescription = plant.PlantDescription,
                NormalPrice = plant.NormalPrice
            };
        }
    }
}