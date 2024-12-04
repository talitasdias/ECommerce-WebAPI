using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ecommerce.DataBase
{
    public class ECommerceDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
        : base(options)
        {
        }
    }
}

public class Category
{
    [Key]
    [Column(TypeName = "text")]
    public string ID { get; set; }

    [Column(TypeName = "text")]
    public string Title { get; set; }

    [Column(TypeName = "text")]
    public string Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }
}
