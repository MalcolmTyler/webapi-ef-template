using Microsoft.AspNetCore.Mvc;
using test_webapi.DTOs;
using test_webapi.Services;

namespace test_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlantCategoriesController : ControllerBase
    {
        private readonly IPlantCategoryService _service;

        public PlantCategoriesController(IPlantCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantCategoryDto>>> GetAllCategories()
        {
            var categories = await _service.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlantCategoryDto>> GetCategory(int id)
        {
            var category = await _service.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<PlantCategoryDto>> CreateCategory(PlantCategoryDto categoryDto)
        {
            var result = await _service.CreateCategoryAsync(categoryDto);
            return CreatedAtAction(nameof(GetCategory), new { id = result.CategoryID }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, PlantCategoryDto categoryDto)
        {
            await _service.UpdateCategoryAsync(id, categoryDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _service.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}