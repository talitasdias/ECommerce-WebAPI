using Ecommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DataBase
{
    public class ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : DbContext(options)
    {
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<UserEntity> Users { get; set; }
    }
}
