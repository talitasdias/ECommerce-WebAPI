using Ecommerce.Entities;

namespace Ecommerce.DTO
{
    public class GetCategoryDTO
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public required string Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public ICollection<ProductDTO>? Products { get; set; }
    }
}
