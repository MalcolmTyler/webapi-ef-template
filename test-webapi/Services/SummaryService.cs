using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using test_webapi.Data;
using test_webapi.DTOs;
using test_webapi.Entities;

namespace test_webapi.Services
{
    public class SummaryService : ISummaryService
    {
        private readonly AppDbContext _context;

        public SummaryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SummaryDto>> GetAllSummariesAsync()
        {
            return await _context.Summaries
                .Select(s => new SummaryDto
                {
                    Id = s.Id,
                    Title = s.Title ?? string.Empty,
                    Description = s.Description ?? string.Empty
                })
                .ToListAsync();
        }

        public async Task<SummaryDto?> GetSummaryByIdAsync(int id)
        {
            var summary = await _context.Summaries.FindAsync(id);
            if (summary == null)
            {
                return null;
            }

            return new SummaryDto
            {
                Id = summary.Id,
                Title = summary.Title ?? string.Empty,
                Description = summary.Description ?? string.Empty
            };
        }

        public async Task<SummaryDto> CreateSummaryAsync(SummaryDto summaryDto)
        {
            var summary = new Summary
            {
                Title = summaryDto.Title ?? string.Empty,
                Description = summaryDto.Description ?? string.Empty
            };

            _context.Summaries.Add(summary);
            await _context.SaveChangesAsync();

            summaryDto.Id = summary.Id;
            return summaryDto;
        }

        public async Task<SummaryDto?> UpdateSummaryAsync(int id, SummaryDto summaryDto)
        {
            var summary = await _context.Summaries.FindAsync(id);
            if (summary == null)
            {
                return null;
            }

            summary.Title = summaryDto.Title ?? string.Empty;
            summary.Description = summaryDto.Description ?? string.Empty;

            await _context.SaveChangesAsync();

            return summaryDto;
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
    }
}