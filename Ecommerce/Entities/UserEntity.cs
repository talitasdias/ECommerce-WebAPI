using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Entities
{
    public class UserEntity
    {
        [Key]
        [Column(TypeName = "integer")]
        public int Id { get; private set; }

        [Column(TypeName = "text")]
        public required string Name { get; set; }

        [Column(TypeName = "text")]
        public required string Email { get; set; }

        [Column(TypeName = "text")]
        public required string Password { get; set; }
    }
}
