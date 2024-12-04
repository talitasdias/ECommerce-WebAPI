using Ecommerce.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Insert([FromBody] Category category)
        {
            try
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCategory{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var category = _context.Categories.FirstOrDefault(category => category.ID == id);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateCategory{id}")]
        public async Task<IActionResult> Update([FromBody] Category category, string id)
        {
            try
            {
                Category categoryData = _context.Categories.FirstOrDefault(category => category.ID == id);
                categoryData.Title = category.Title;
                categoryData.Description = category.Description;
                _context.Categories.Update(categoryData);
                await _context.SaveChangesAsync();
                return Ok(categoryData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
