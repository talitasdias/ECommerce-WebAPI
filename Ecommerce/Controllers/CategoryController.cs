using Ecommerce.DataBase;
using Ecommerce.DTO.Category;
using Ecommerce.Entities;
using Ecommerce.Mapper;
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

                CreateCategoryOutputDTO result = CategoryEntityToCreateCategoryOutputDTO.Make(category);

                return StatusCode(201, result);
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

                GetCategoryDTO result = CategoryEntityToGetCategoryDTO.Make(category);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            try
            {
                List<CategoryEntity> listCategory = _context.Categories.ToList();

                var result = CategoryEntityToGetAllCategoryDTO.Make(listCategory);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateCategory/{id}")]
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

                UpdateCategoryOutputDTO result = CategoryEntityToUpdateCategoryOutputDTO.Make(categoryData);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteCategory/{id}")]
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
