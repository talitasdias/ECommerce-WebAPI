using Ecommerce.Entities;

namespace Ecommerce.DTO
{
    public class GetProductDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public required CategoryEntity Category { get; set; }
    }
}
