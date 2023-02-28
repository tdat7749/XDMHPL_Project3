using BanHangMVC.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BanHangMVC.Configuration
{
    public class VegetableConfiguration : IEntityTypeConfiguration<Vegetable>
    {
        public void Configure(EntityTypeBuilder<Vegetable> builder)
        {
            builder.ToTable("Vegetables");
            builder.HasKey(x => x.VegetableID);

            builder.Property(x => x.VegetableID).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Unit).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Amount).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Image).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Sold).IsRequired().HasDefaultValue(0);

            builder.HasOne(x => x.Category).WithMany(x => x.Vegetables).HasForeignKey(x => x.CategoryID);
        }
    }
}
