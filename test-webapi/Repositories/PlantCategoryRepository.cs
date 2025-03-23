using Microsoft.EntityFrameworkCore;
using test_webapi.Data;
using test_webapi.Data.Entities;

namespace test_webapi.Repositories
{
    public class PlantCategoryRepository : IPlantCategoryRepository
    {
        private readonly AppDbContext _context;

        public PlantCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlantCategoryEntity>> GetAllAsync()
        {
            return await _context.PlantCategories
                .Include(c => c.Plants)
                .ToListAsync();
        }

        public async Task<PlantCategoryEntity?> GetByIdAsync(int id)
        {
            return await _context.PlantCategories
                .Include(c => c.Plants)
                .FirstOrDefaultAsync(c => c.CategoryID == id);
        }

        public async Task<PlantCategoryEntity> AddAsync(PlantCategoryEntity category)
        {
            _context.PlantCategories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task UpdateAsync(PlantCategoryEntity category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.PlantCategories.FindAsync(id);
            if (category != null)
            {
                _context.PlantCategories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}