using Microsoft.EntityFrameworkCore;
using test_webapi.Data;
using test_webapi.Data.Entities;

namespace test_webapi.Repositories
{
    public class PlantHoldingRepository : IPlantHoldingRepository
    {
        private readonly AppDbContext _context;

        public PlantHoldingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlantHolding>> GetAllAsync()
        {
            return await _context.PlantHoldings
                .Include(p => p.Customer)
                .Include(p => p.Plant)
                .Include(p => p.Status)
                .ToListAsync();
        }

        public async Task<PlantHolding?> GetByIdAsync(int id)
        {
            return await _context.PlantHoldings
                .Include(p => p.Customer)
                .Include(p => p.Plant)
                .Include(p => p.Status)
                .FirstOrDefaultAsync(p => p.HoldingID == id);
        }

        public async Task<IEnumerable<PlantHolding>> GetByCustomerAsync(int customerId)
        {
            return await _context.PlantHoldings
                .Include(p => p.Customer)
                .Include(p => p.Plant)
                .Include(p => p.Status)
                .Where(p => p.CustID == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<PlantHolding>> GetByStatusAsync(int statusId)
        {
            return await _context.PlantHoldings
                .Include(p => p.Customer)
                .Include(p => p.Plant)
                .Include(p => p.Status)
                .Where(p => p.StatusID == statusId)
                .ToListAsync();
        }

        public async Task<PlantHolding> AddAsync(PlantHolding plantHolding)
        {
            await _context.PlantHoldings.AddAsync(plantHolding);
            await _context.SaveChangesAsync();
            return plantHolding;
        }

        public async Task UpdateAsync(PlantHolding plantHolding)
        {
            _context.Entry(plantHolding).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var plantHolding = await _context.PlantHoldings.FindAsync(id);
            if (plantHolding != null)
            {
                _context.PlantHoldings.Remove(plantHolding);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.PlantHoldings.AnyAsync(p => p.HoldingID == id);
        }
    }
}