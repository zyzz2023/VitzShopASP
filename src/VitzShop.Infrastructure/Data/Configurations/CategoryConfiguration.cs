using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitzShop.Infrastructure.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasConversion(
                    n => n.Value,
                    v => Name.Create(v))
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.ImageUrl)
                .HasConversion(
                    u => u.Value,
                    v => Url.Create(v))
                .HasColumnName("Url")
                .HasMaxLength(500);

            //builder.HasMany(c => c.Products)
            //    .WithOne(p => p.Category)
            //    .HasForeignKey(p => p.CategoryId)
            //    .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(c => c.Name).IsUnique();
        }
    }
}
