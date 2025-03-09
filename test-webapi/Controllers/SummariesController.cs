using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using test_webapi.Services;
using test_webapi.DTOs;

namespace test_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummariesController : ControllerBase
    {
        private readonly ISummaryService _summaryService;

        public SummariesController(ISummaryService summaryService)
        {
            _summaryService = summaryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SummaryDto>>> GetSummaries()
        {
            var summaries = await _summaryService.GetAllSummariesAsync();
            return Ok(summaries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SummaryDto>> GetSummary(int id)
        {
            var summary = await _summaryService.GetSummaryByIdAsync(id);
            if (summary == null)
            {
                return NotFound();
            }
            return Ok(summary);
        }

        [HttpPost]
        public async Task<ActionResult<SummaryDto>> CreateSummary(SummaryDto summaryDto)
        {
            var createdSummary = await _summaryService.CreateSummaryAsync(summaryDto);
            return CreatedAtAction(nameof(GetSummary), new { id = createdSummary.Id }, createdSummary);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSummary(int id, SummaryDto summaryDto)
        {
            var updatedSummary = await _summaryService.UpdateSummaryAsync(id, summaryDto);
            if (updatedSummary == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSummary(int id)
        {
            await _summaryService.DeleteSummaryAsync(id);
            return NoContent();
        }
    }
}