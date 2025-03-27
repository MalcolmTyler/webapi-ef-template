using Microsoft.AspNetCore.Mvc;
using test_webapi.DTOs;
using test_webapi.Services;

namespace test_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _service;

        public StatusController(IStatusService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusDto>>> GetAllStatus()
        {
            var Status = await _service.GetAllStatusAsync();
            return Ok(Status);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatusDto>> GetStatus(int id)
        {
            var status = await _service.GetStatusByIdAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return Ok(status);
        }

        [HttpPost]
        public async Task<ActionResult<StatusDto>> CreateStatus(StatusDto statusDto)
        {
            var result = await _service.CreateStatusAsync(statusDto);
            return CreatedAtAction(nameof(GetStatus), new { id = result.StatusID }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatus(int id, StatusDto statusDto)
        {
            await _service.UpdateStatusAsync(id, statusDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            await _service.DeleteStatusAsync(id);
            return NoContent();
        }
    }
}