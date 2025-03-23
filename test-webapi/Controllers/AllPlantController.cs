using Microsoft.AspNetCore.Mvc;
using test_webapi.DTOs;
using test_webapi.Services;

namespace test_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AllPlantController : ControllerBase
    {
        private readonly IAllPlantService _service;

        public AllPlantController(IAllPlantService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllPlantDto>>> GetAllPlants()
        {
            var plants = await _service.GetAllPlantsAsync();
            return Ok(plants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AllPlantDto>> GetPlant(int id)
        {
            var plant = await _service.GetPlantByIdAsync(id);
            if (plant == null)
            {
                return NotFound();
            }
            return Ok(plant);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<AllPlantDto>>> GetPlantsByCategory(int categoryId)
        {
            var plants = await _service.GetPlantsByCategoryAsync(categoryId);
            return Ok(plants);
        }

        [HttpPost]
        public async Task<ActionResult<AllPlantDto>> CreatePlant(AllPlantDto plantDto)
        {
            var result = await _service.CreatePlantAsync(plantDto);
            return CreatedAtAction(nameof(GetPlant), new { id = result.PlantNameID }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlant(int id, AllPlantDto plantDto)
        {
            await _service.UpdatePlantAsync(id, plantDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlant(int id)
        {
            await _service.DeletePlantAsync(id);
            return NoContent();
        }
    }
}