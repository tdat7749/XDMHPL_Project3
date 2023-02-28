using BanHangMVC.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BanHangMVC.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.OrderID);
            builder.Property(x => x.OrderID).UseIdentityColumn();

            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Total).IsRequired();
            builder.Property(x => x.Note).IsRequired();
            builder.Property(x => x.Address).IsRequired();

            builder.HasOne(x => x.Customer).WithMany(x => x.Orders).HasForeignKey(x => x.CustomerID);
        }
    }
}
