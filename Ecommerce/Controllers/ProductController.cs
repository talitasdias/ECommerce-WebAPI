using Ecommerce.DataBase;
using Ecommerce.DTO;
using Ecommerce.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

            return StatusCode(201, "criado");
        }
    }
}
