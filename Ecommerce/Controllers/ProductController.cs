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
    public class ProductController : ControllerBase
    {
        private readonly ECommerceDbContext _context;

        public ProductController(ECommerceDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> InsertProduct([FromBody] ProductDTO productDto)
        {
            try
            {
                var categoryExisting = _context.Categories.FirstOrDefault(cat => cat.Id == productDto.CategoryId);
                if (categoryExisting == null)
                    return NotFound($"There is not Category for the Id {productDto.CategoryId}");

                ProductEntity product = new()
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    Quantity = productDto.Quantity,
                    CategoryId = productDto.CategoryId,
                    Category = categoryExisting
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                return StatusCode(201, "Product created successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var productExisting = await _context.Products
                    .Include(cat => cat.Category)
                    .FirstOrDefaultAsync(pro => pro.Id == id);

                if (productExisting == null)
                    return NotFound($"There is not product for the Id {id}");

                return Ok(productExisting);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
