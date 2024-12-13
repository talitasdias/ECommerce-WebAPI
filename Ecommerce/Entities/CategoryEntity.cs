using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Entities
{
    public class CategoryEntity
    {
        [Key]
        [Column(TypeName = "integer")]
        public int Id { get; private set; }

        [Column(TypeName = "text")]
        public required string Title { get; set; }

        [Column(TypeName = "text")]
        public required string Description { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
    }
}
