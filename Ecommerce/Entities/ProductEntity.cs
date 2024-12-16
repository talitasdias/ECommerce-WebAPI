using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Entities
{
    public class ProductEntity
    {
        [Key]
        [Column(TypeName = "integer")]
        public int Id { get; private set; }

        [Column(TypeName = "text")]
        public required string Name { get; set; }

        [Column(TypeName = "double")]
        public double Price { get; set; }

        [Column(TypeName = "integer")]
        public int Quantity { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; private set; } = DateTime.Now;

        [Column(TypeName = "bool")]
        public bool IsActive { get; set; }

        [Column(TypeName = "integer")]
        public int CategoryId { get; set; }

        public required CategoryEntity Category { get; set; }
    }
}
