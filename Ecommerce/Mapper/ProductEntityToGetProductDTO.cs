using Ecommerce.DTO.Category;
using Ecommerce.DTO.Product;
using Ecommerce.Entities;

namespace Ecommerce.Mapper
{
    public class ProductEntityToGetProductDTO
    {
        public static GetProductDTO Make(ProductEntity product)
        {
            GetProductDTO productOutput = new()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreatedAt = product.CreatedAt,
                Category = new CategoryDTO()
                {
                    Id = product.Category.Id,
                    Title = product.Category.Title,
                    Description = product.Category.Description,
                    CreatedAt = product.Category.CreatedAt,
                    IsActive = product.Category.IsActive
                }
            };

            return productOutput;
        }
    }
}
