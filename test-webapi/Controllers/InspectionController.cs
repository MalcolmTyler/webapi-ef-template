using Microsoft.AspNetCore.Mvc;
using test_webapi.DTOs;
using test_webapi.Services;

namespace test_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InspectionController : ControllerBase
    {
        private readonly IInspectionService _service;

        public InspectionController(IInspectionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InspectionReadDto>>> GetAllInspections()
        {
            var inspections = await _service.GetAllInspectionsAsync();
            return Ok(inspections);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InspectionReadDto>> GetInspection(int id)
        {
            var inspection = await _service.GetInspectionByIdAsync(id);
            if (inspection == null)
            {
                return NotFound();
            }
            return Ok(inspection);
        }

        [HttpGet("plantholding/{holdingId}")]
        public async Task<ActionResult<IEnumerable<InspectionReadDto>>> GetByPlantHolding(int holdingId)
        {
            var inspections = await _service.GetInspectionsByPlantHoldingAsync(holdingId);
            return Ok(inspections);
        }

        [HttpPost]
        public async Task<ActionResult<InspectionReadDto>> CreateInspection(InspectionDto inspectionDto)
        {
            var createdInspection = await _service.CreateInspectionAsync(inspectionDto);
            return CreatedAtAction(nameof(GetInspection), new { id = createdInspection.UniqueRef }, createdInspection);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<InspectionReadDto>> UpdateInspection(int id, InspectionDto inspectionDto)
        {
            var updatedInspection = await _service.UpdateInspectionAsync(id, inspectionDto);
            return Ok(updatedInspection);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspection(int id)
        {
            await _service.DeleteInspectionAsync(id);
            return NoContent();
        }
    }
}