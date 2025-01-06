using Ecommerce.DTO.Product;
using Ecommerce.Entities;

namespace Ecommerce.Mapper
{
    public class ProductEntityToCreateProductOutputDTO
    {
        public static CreateProductOutputDTO Make(ProductEntity product)
        {
            CreateProductOutputDTO productOutput = new()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreatedAt = product.CreatedAt,
                CategoryId = product.CategoryId
            };

            return productOutput;
        }
    }
}
