using BanHangMVC.Configuration;
using BanHangMVC.Entities;
using Microsoft.EntityFrameworkCore;

namespace BanHangMVC.EF
{
    public class BanHangDbContext : DbContext
    {
        public BanHangDbContext(DbContextOptions<BanHangDbContext> option) : base(option)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new VegetableConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Vegetable> Vegetables { get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<OrderDetail> OrderDetails{ get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Customer> Customers{ get; set; }
    }
}
