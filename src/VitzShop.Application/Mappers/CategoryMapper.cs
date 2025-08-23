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
    public class CategoryMapper
    {
        public static CategoryDto MapToDto(Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name.Value,
                ImageUrl = category.ImageUrl.Value
            };
        }

        public static Category MapFromDto(CategoryDto dto)
        {
            return Category.Create(
                Name.Create(dto.Name),
                Url.Create(dto.ImageUrl)
            );
        }
    }
}
