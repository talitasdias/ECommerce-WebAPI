using Ecommerce.DTO.Category;

namespace Ecommerce.DTO.Product
{
    public class GetProductDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public required CategoryDTO Category { get; set; }
    }
}
