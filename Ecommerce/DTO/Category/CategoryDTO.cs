namespace Ecommerce.DTO.Category
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public required string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }
    }
}
