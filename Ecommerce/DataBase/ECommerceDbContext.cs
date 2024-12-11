using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ecommerce.DataBase
{
    public class ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : DbContext(options)
    {
        public DbSet<Category> Categories { get; set; }
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
