using Ecommerce.DTO.Product;
using Ecommerce.DTO.Category;
using Ecommerce.Entities;

namespace Ecommerce.Mapper
{
    public class CategoryEntityToGetCategoryDTO
    {
        public static GetCategoryDTO Make(CategoryEntity category)
        {
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

            return categoryDTO;
        }
    }
}
