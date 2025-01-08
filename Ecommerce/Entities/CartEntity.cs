using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Entities
{
    public class CartEntity
    {
        [Key]
        [Column(TypeName = "integer")]
        public int Id { get; private set; }

        [Column(TypeName = "integer")]
        public int UserId { get; set; }

        [Column(TypeName = "double")]
        public double Total { get; set; }

        public required UserEntity User { get; set; }

        public List<CartItemEntity> CartItem { get; set; } = new List<CartItemEntity>();
    }
}
