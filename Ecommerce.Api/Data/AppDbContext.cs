using Ecommerce.Api.Models;
using Ecommerce.Api.Models.UserModels;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options)
        : DbContext(options)
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<CartItem> Items => Set<CartItem>();

    }
}
