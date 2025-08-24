using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitzShop.Infrastructure.Data.Configurations
{
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.ToTable("ProductVariants");

            builder.HasKey(pv => pv.Id);

            builder.Property(pv => pv.Color)
                .HasConversion(
                    c => new { c.Value, c.HexCode },
                    v => ProductColor.Create(v.Value, v.HexCode))
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("Color");

            builder.Property(pv => pv.Size)
                .HasConversion(
                    s => s.Value,
                    v => ProductSize.Create(v))
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnName("Size");

            builder.Property(pv => pv.Quantity)
                .IsRequired()
                .HasColumnName("Quantity");

            builder.Property(pv => pv.Sku)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("SKU");

            builder.HasOne(pv => pv.Product)
                .WithMany(p => p.Variants)
                .HasForeignKey(pv => pv.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.OwnsMany(pv => pv.Images, img =>
            {
                img.WithOwner().HasForeignKey("ProductVariantId");
                img.Property<Guid>("Id"); // Shadow primary key
                img.HasKey("Id");
                img.ToTable("ProductVariantImages"); // Можно указать явное имя таблицы
            });

            builder.HasIndex(pv => new { pv.ProductId, pv.Color, pv.Size }).IsUnique();

            builder.HasIndex(pv => pv.Sku).IsUnique();
            builder.HasIndex(pv => pv.ProductId);
        }
    }
}