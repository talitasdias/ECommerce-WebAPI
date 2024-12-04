using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


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
    [JsonIgnore]
    public string ID { get; private set; } = Guid.NewGuid().ToString();

    [Column(TypeName = "text")]
    public string Title { get; set; }

    [Column(TypeName = "text")]
    public string Description { get; set; }

    [Column(TypeName = "datetime")]
    [JsonIgnore]
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
}
