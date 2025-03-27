using Microsoft.EntityFrameworkCore;
using test_webapi.Data;
using test_webapi.Data.Entities;

namespace test_webapi.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly AppDbContext _context;

        public StatusRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Status>> GetStatusAsync()
        {
            return await _context.Status
                .Include(s => s.StatusDescription)
                .ToListAsync();
        }

        public async Task<Status?> GetStatusAsync(int id)
        {
            return await _context.Status
                .Include(s => s.StatusDescription)
                .FirstOrDefaultAsync(s => s.StatusID == id);
        }

        public async Task<Status> AddStatusAsync(Status status)
        {
            await _context.Status.AddAsync(status);
            await _context.SaveChangesAsync();
            return status;
        }

        public async Task UpdateStatusAsync(Status status)
        {
            _context.Entry(status).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStatusAsync(int id)
        {
            var status = await _context.Status.FindAsync(id);
            if (status != null)
            {
                _context.Status.Remove(status);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> StatusExistsAsync(int id)
        {
            return await _context.Status.AnyAsync(s => s.StatusID == id);
        }
    }
}