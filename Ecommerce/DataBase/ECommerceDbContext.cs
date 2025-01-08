using Ecommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DataBase
{
    public class ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : DbContext(options)
    {
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CartEntity> Cart {  get; set; }
        public DbSet<CartItemEntity> CartItem { get; set; }
    }
}
