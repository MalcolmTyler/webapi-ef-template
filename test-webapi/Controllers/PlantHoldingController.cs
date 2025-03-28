using Microsoft.AspNetCore.Mvc;
using test_webapi.DTOs;
using test_webapi.Services;

namespace test_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlantHoldingController : ControllerBase
    {
        private readonly IPlantHoldingService _service;

        public PlantHoldingController(IPlantHoldingService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantHoldingReadDto>>> GetAllHoldings()
        {
            var holdings = await _service.GetAllHoldingsAsync();
            return Ok(holdings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlantHoldingReadDto>> GetHolding(int id)
        {
            var holding = await _service.GetHoldingByIdAsync(id);
            if (holding == null)
            {
                return NotFound();
            }
            return Ok(holding);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<PlantHoldingReadDto>>> GetByCustomer(int customerId)
        {
            var holdings = await _service.GetHoldingsByCustomerAsync(customerId);
            return Ok(holdings);
        }

        [HttpGet("status/{statusId}")]
        public async Task<ActionResult<IEnumerable<PlantHoldingReadDto>>> GetByStatus(int statusId)
        {
            var holdings = await _service.GetHoldingsByStatusAsync(statusId);
            return Ok(holdings);
        }

        [HttpPost]
        public async Task<ActionResult<PlantHoldingReadDto>> CreateHolding(PlantHoldingDto holdingDto)
        {
            var createdHolding = await _service.CreateHoldingAsync(holdingDto);
            return CreatedAtAction(nameof(GetHolding), new { id = createdHolding.HoldingID }, createdHolding);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PlantHoldingReadDto>> UpdateHolding(int id, PlantHoldingDto holdingDto)
        {
            var updatedHolding = await _service.UpdateHoldingAsync(id, holdingDto);
            return Ok(updatedHolding);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHolding(int id)
        {
            await _service.DeleteHoldingAsync(id);
            return NoContent();
        }
    }
}