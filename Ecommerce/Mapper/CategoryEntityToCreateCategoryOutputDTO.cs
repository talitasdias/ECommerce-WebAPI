using Ecommerce.DTO.Category;
using Ecommerce.Entities;

namespace Ecommerce.Mapper
{
    public class CategoryEntityToCreateCategoryOutputDTO
    {
        public static CreateCategoryOutputDTO Make(CategoryEntity category)
        {
            CreateCategoryOutputDTO categoryOutput = new()
            {
                Id = category.Id,
                Title = category.Title,
                Description = category.Description,
                CreatedAt = category.CreatedAt
            };

            return categoryOutput;
        }
    }
}
