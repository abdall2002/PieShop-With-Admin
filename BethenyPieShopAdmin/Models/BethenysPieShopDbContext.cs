using Microsoft.EntityFrameworkCore;

namespace BethenyPieShopAdmin.Models
{
    public class BethenysPieShopDbContext : DbContext
    {
        public BethenysPieShopDbContext(DbContextOptions<BethenysPieShopDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Pie> Pies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BethenysPieShopDbContext).Assembly);

            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Pie>().ToTable("Pies");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetails");

            // configuaration using Fluent Api
            modelBuilder.Entity<Category>().Property(b => b.Name).IsRequired();
        }
    }
}
