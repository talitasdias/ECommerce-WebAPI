using Ecommerce.DataBase;
using Ecommerce.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ECommerceDbContext _context;

        public CategoryController(ECommerceDbContext context)
        {
            _context = context;
        }

        [HttpPost("InsertCategory")]
        public async Task<IActionResult> Insert([FromBody] CategoryDTO categoryDto)
        {
            try
            {
                Category categoryData = _context.Categories.FirstOrDefault(cat => cat.Title == categoryDto.Title);

                if (categoryData != null)
                    return Conflict("Category already exists in the database!");

                Category category = new()
                {
                    Title = categoryDto.Title,
                    Description = categoryDto.Description
                };

                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetCategory/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                Category category = _context.Categories.FirstOrDefault(category => category.ID == id);

                if (category == null)
                    return NotFound($"No record was found for the ID: {id}");

                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateCategory{id}")]
        public async Task<IActionResult> Update([FromBody] CategoryDTO categoryDTO, string id)
        {
            try
            {
                Category categoryData = _context.Categories.FirstOrDefault(category => category.ID == id);

                if (categoryData == null)
                    return NotFound($"No record was found for the ID: {id}");

                categoryData.Title = categoryDTO.Title;
                categoryData.Description = categoryDTO.Description;

                _context.Categories.Update(categoryData);
                await _context.SaveChangesAsync();

                return Ok(categoryData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteCategory{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                Category category = _context.Categories.FirstOrDefault(category => category.ID == id);

                if (category == null)
                    return NotFound($"No record was found for the ID: {id}");

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                return Ok("Sucessfully removed!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
