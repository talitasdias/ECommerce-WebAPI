using Ecommerce.DataBase;
using Ecommerce.DTO;
using Ecommerce.Entities;
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
        public async Task<IActionResult> Insert([FromBody] CreateCategoryInputDTO categoryDto)
        {
            try
            {
                CategoryEntity? categoryData = _context.Categories.FirstOrDefault(cat => cat.Title == categoryDto.Title);

                if (categoryData != null)
                    return Conflict("Category already exists in the database!");

                CategoryEntity category = new()
                {
                    Title = categoryDto.Title,
                    Description = categoryDto.Description
                };

                _context.Categories.Add(category);
                await _context.SaveChangesAsync();

                CreateCategoryOutputDTO categoryOutput = new()
                {
                    Id = category.Id,
                    Title = category.Title,
                    Description = category.Description,
                    CreatedAt = category.CreatedAt
                };

                return StatusCode(201, categoryOutput);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetCategory/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                CategoryEntity? category = _context.Categories
                    .Include(cat => cat.Products)
                    .FirstOrDefault(category => category.Id == id);

                if (category == null)
                    return NotFound($"No record was found for the ID: {id}");

                GetCategoryDTO categoryDTO = new()
                {
                    Id = category.Id,
                    Title = category.Title,
                    Description = category.Description,
                    CreatedAt = category.CreatedAt,
                    IsActive = category.IsActive,
                    Products = category.Products?.Select(pro => new ProductDTO
                    {
                        Id = pro.Id,
                        Name = pro.Name,
                        Price = pro.Price,
                        Quantity = pro.Quantity,
                        CreatedAt = pro.CreatedAt,
                        IsActive = pro.IsActive
                    }).ToList()
                };

                return Ok(categoryDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateCategory{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryInputDTO categoryDTO, int id)
        {
            try
            {
                CategoryEntity? categoryData = _context.Categories.FirstOrDefault(category => category.Id == id);

                if (categoryData == null)
                    return NotFound($"No record was found for the ID: {id}");

                categoryData.Title = categoryDTO.Title;
                categoryData.Description = categoryDTO.Description;

                _context.Categories.Update(categoryData);
                await _context.SaveChangesAsync();

                UpdateCategoryOutputDTO categoryOutput = new()
                {
                    Id = categoryData.Id,
                    Title = categoryData.Title,
                    Description = categoryData.Description,
                    CreatedAt = categoryData.CreatedAt,
                    IsActive = categoryData.IsActive
                };

                return Ok(categoryOutput);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteCategory{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                CategoryEntity? category = _context.Categories.FirstOrDefault(category => category.Id == id);

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
