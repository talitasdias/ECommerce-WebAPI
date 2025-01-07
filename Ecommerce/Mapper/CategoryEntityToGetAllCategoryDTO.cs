using Ecommerce.DTO.Category;
using Ecommerce.Entities;

namespace Ecommerce.Mapper
{
    public class CategoryEntityToGetAllCategoryDTO
    {
        public static List<GetAllCategoryDTO> Make(List<CategoryEntity> listCategories)
        {
            List<GetAllCategoryDTO> listCategoryDTO = new List<GetAllCategoryDTO>();
            foreach (CategoryEntity entity in listCategories)
            {
                var categoryDTO = new GetAllCategoryDTO()
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Description = entity.Description,
                    CreatedAt = entity.CreatedAt,
                    IsActive = entity.IsActive
                };

                listCategoryDTO.Add(categoryDTO);
            }

            return listCategoryDTO;
        }
    }
}
