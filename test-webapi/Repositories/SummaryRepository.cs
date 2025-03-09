using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using test_webapi;
using test_webapi.Data;
using test_webapi.Entities;

namespace test_webapi.Repositories
{
    public class SummaryRepository : ISummaryRepository
    {
        private readonly AppDbContext _context;

        public SummaryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Summary>> GetSummariesAsync()
        {
            return await _context.Summaries.ToListAsync();
        }

        public async Task<Summary?> GetSummaryAsync(int id)
        {
            return await _context.Summaries.FindAsync(id);
        }

        public async Task AddSummaryAsync(Summary summary)
        {
            _context.Summaries.Add(summary);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSummaryAsync(Summary summary)
        {
            _context.Entry(summary).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSummaryAsync(int id)
        {
            var summary = await _context.Summaries.FindAsync(id);
            if (summary != null)
            {
                _context.Summaries.Remove(summary);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> SummaryExistsAsync(int id)
        {
            return await _context.Summaries.AnyAsync(e => e.Id == id);
        }
    }
}