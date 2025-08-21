using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitzShop.Infrastructure.Data.Repositories.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Images");

            builder.HasKey(pi => pi.Id);

            builder.Property(pi => pi.ImageUrl)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(pi => pi.IsMain)
                .IsRequired();

            builder.Property(pi => pi.DisplayOrder)
                .IsRequired();

            builder.HasOne(i => i.ProductVariant)
                .WithMany(pv => pv.Images)
                .HasForeignKey(i => i.ProductVariantId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
