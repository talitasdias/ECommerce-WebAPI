using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Entities
{
    public class CartItemEntity
    {
        [Key]
        [Column(TypeName = "integer")]
        public int Id { get; private set; }

        [Column(TypeName = "text")]
        public required string Name { get; set; }

        [Column(TypeName = "integer")]
        public int Quantity { get; set; }

        [Column(TypeName = "double")]
        public double Price { get; set; }

        [Column(TypeName = "integer")]
        public int ProductId { get; set; }

        [Column(TypeName = "integer")]
        public int CartId { get; set; }

        public required ProductEntity Product { get; set; }

        public required CartEntity Cart { get; set; }
    }
}
