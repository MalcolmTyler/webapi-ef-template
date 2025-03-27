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
        public async Task<ActionResult<IEnumerable<PlantHoldingDto>>> GetAllHoldings()
        {
            var holdings = await _service.GetAllHoldingsAsync();
            return Ok(holdings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlantHoldingDto>> GetHolding(int id)
        {
            var holding = await _service.GetHoldingByIdAsync(id);
            if (holding == null)
            {
                return NotFound();
            }
            return Ok(holding);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<PlantHoldingDto>>> GetByCustomer(int customerId)
        {
            var holdings = await _service.GetHoldingsByCustomerAsync(customerId);
            return Ok(holdings);
        }

        [HttpGet("status/{statusId}")]
        public async Task<ActionResult<IEnumerable<PlantHoldingDto>>> GetByStatus(int statusId)
        {
            var holdings = await _service.GetHoldingsByStatusAsync(statusId);
            return Ok(holdings);
        }

        [HttpPost]
        public async Task<ActionResult<PlantHoldingDto>> CreateHolding(PlantHoldingDto holdingDto)
        {
            var result = await _service.CreateHoldingAsync(holdingDto);
            return CreatedAtAction(nameof(GetHolding), new { id = result.HoldingID }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PlantHoldingDto>> UpdateHolding(int id, PlantHoldingDto holdingDto)
        {
            await _service.UpdateHoldingAsync(id, holdingDto);
            var updatedHolding = await _service.GetHoldingByIdAsync(id);
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