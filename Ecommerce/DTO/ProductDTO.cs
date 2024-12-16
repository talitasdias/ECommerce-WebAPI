using Ecommerce.Entities;

namespace Ecommerce.DTO
{
    public class ProductDTO
    {
        public required string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
    }
}
