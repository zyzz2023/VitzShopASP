using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitzShop.Application.Common;
using VitzShop.Application.DTOs;

namespace VitzShop.Application.Interfaces
{
    public interface IProductService
    {
        Task<Result<ProductDto>> CreateProductAsync(string name, string description, decimal price, string mainImageUrl, Guid categoryId, CancellationToken cancellationToken);
        Task<Result<ProductDto>> AddProductVariantAsync(Guid productId, string colorName, string colorHexCode, string size, int quantity, CancellationToken cancellationToken);
        Task<Result<ProductDto>> UpdateProductVariantQuantityAsync(Guid productId, string colorName, string colorHexCode, string size, int newQuantity, CancellationToken cancellationToken);
        Task<Result<ProductDto>> GetProductByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
