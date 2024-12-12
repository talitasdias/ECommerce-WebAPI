using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ecommerce.DataBase
{
    public class ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : DbContext(options)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

public class Category
{
    [Key]
    [Column(TypeName = "text")]
    public string ID { get; private set; } = Guid.NewGuid().ToString();

    [Column(TypeName = "text")]
    public string Title { get; set; }

    [Column(TypeName = "text")]
    public string Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
}

public class User
{
    [Key]
    [Column(TypeName = "integer")]
    public int UserId { get; private set; }

    [Column(TypeName = "text")]
    public string Name { get; set; }

    [Column(TypeName = "text")]
    public string Email { get; set; }

    [Column(TypeName = "text")]
    public string Senha { get; private set; }
}
