using Ecommerce.DTO.Category;
using Ecommerce.Entities;

namespace Ecommerce.Mapper
{
    public class CategoryEntityToUpdateCategoryOutputDTO
    {
        public static UpdateCategoryOutputDTO Make(CategoryEntity categoryData)
        {
            UpdateCategoryOutputDTO categoryOutput = new()
            {
                Id = categoryData.Id,
                Title = categoryData.Title,
                Description = categoryData.Description,
                CreatedAt = categoryData.CreatedAt,
                IsActive = categoryData.IsActive
            };

            return categoryOutput;
        }
    }
}
