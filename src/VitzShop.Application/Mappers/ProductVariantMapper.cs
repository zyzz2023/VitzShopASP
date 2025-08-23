using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VitzShop.Application.DTOs;
using VitzShop.Domain.Entities;
using VitzShop.Domain.ValueObjects;

namespace VitzShop.Application.Mappers
{
    public class ProductVariantMapper
    {
        public static ProductVariantDto MapToDto(ProductVariant productVariant)
        {
            return new ProductVariantDto
            {
                Id = productVariant.Id,
                ColorName = productVariant.Color.Value,
                ColorHexCode = productVariant.Color.HexCode,
                Size = productVariant.Size.Value,
                Quantity = productVariant.Quantity,
                Sku = productVariant.Sku,
                ProductId = productVariant.ProductId,
                Images = productVariant.Images
                .Select(image => new ImageDto
                {
                    ImageUrl = image.ImageUrl,
                    IsMain = image.IsMain,
                    DisplayOrder = image.DisplayOrder
                })
                .ToList()
            };
        }
            public static ProductVariant FromDto(ProductVariantDto dto)
            {
                return ProductVariant.Create(
                    ProductColor.Create(dto.ColorName, dto.ColorHexCode),
                    ProductSize.Create(dto.Size),
                    dto.Quantity,
                    dto.ProductId
                    );
            }
    }
}
