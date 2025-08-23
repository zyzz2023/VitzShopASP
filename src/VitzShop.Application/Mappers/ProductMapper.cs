using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitzShop.Application.DTOs;
using VitzShop.Domain.Entities;
using VitzShop.Domain.ValueObjects;

namespace VitzShop.Application.Mappers
{
    public class ProductMapper
    {
        public static ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name.Value,
                Description = product.Description.Value,
                Price = product.Price.Amount,
                CategoryId = product.CategoryId,
                MainImageUrl = product.MainImage.ImageUrl
            };
        }
        public static Product MapFromDto(ProductDto product)
        {
            return Product.Create(
                product.Name,
                product.Description,
                product.Price,
                Image.Create(product.MainImageUrl),
                product.CategoryId
                );
        }
    }
}
