namespace Ecommerce.DTO.Category
{
    public class CreateCategoryOutputDTO
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public required string Description { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
