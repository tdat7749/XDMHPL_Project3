using BanHangMVC.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BanHangMVC.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(x => x.CustomerID);
            builder.Property(x => x.CustomerID).UseIdentityColumn();
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(50);
            builder.Property(x => x.City).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(50);
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(50);
        }
    }
}
