using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitzShop.Infrastructure.Data.Repositories.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            // Value Objects
            builder.Property(p => p.Name)
                .HasConversion(
                    n => n.Value,
                    v => Name.Create(v))
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasConversion(
                    d => d.Value,
                    v => ProductDescription.Create(v))
                .HasColumnName("Description")
                .HasMaxLength(200);

            builder.Property(p => p.Price)
                .HasConversion(
                    p => p.Amount,
                    v => Money.Create(v))
                .HasColumnName("Price")
                .HasColumnType("decimal(18,2)");

            builder.HasOne(p => p.MainImage)
            .WithOne()
            .HasForeignKey<Product>(p => p.MainImageId)
            .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.Variants)
                .WithOne(pv => pv.Product)
                .HasForeignKey(pv => pv.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(p => p.Name);
            builder.HasIndex(p => p.CategoryId);
            builder.HasIndex(p => new { p.Name, p.CategoryId });
        }
    }
