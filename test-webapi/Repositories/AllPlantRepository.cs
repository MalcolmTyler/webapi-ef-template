using Microsoft.EntityFrameworkCore;
using test_webapi.Data;
using test_webapi.Data.Entities;

namespace test_webapi.Repositories
{
    public class AllPlantRepository : IAllPlantRepository
    {
        private readonly AppDbContext _context;

        public AllPlantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AllPlantEntity>> GetAllAsync()
        {
            return await _context.AllPlants.ToListAsync();
        }

        public async Task<AllPlantEntity?> GetByIdAsync(int id)
        {
            return await _context.AllPlants
                .FirstOrDefaultAsync(p => p.PlantNameID == id);
        }

        public async Task<IEnumerable<AllPlantEntity>> GetByCategoryAsync(int categoryId)
        {
            return await _context.AllPlants
                .Where(p => p.PlantCategory == categoryId)
                .ToListAsync();
        }

        public async Task<AllPlantEntity> AddAsync(AllPlantEntity plant)
        {
            _context.AllPlants.Add(plant);
            await _context.SaveChangesAsync();
            return plant;
        }

        public async Task UpdateAsync(AllPlantEntity plant)
        {
            _context.Entry(plant).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var plant = await _context.AllPlants.FindAsync(id);
            if (plant != null)
            {
                _context.AllPlants.Remove(plant);
                await _context.SaveChangesAsync();
            }
        }
    }
}