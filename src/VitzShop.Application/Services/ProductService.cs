using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitzShop.Application.Common;
using VitzShop.Application.DTOs;
using VitzShop.Application.Interfaces;
using VitzShop.Application.Mappers;
using VitzShop.Domain.Repository;
using VitzShop.Domain.Entities;
using VitzShop.Domain.ValueObjects;
using VitzShop.Domain.Exceptions;
using VitzShop.Domain.Exceptions.InvalidExceptions;

namespace VitzShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(ICategoryRepository categoryRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<ProductDto>> CreateProductAsync(string productName, string productDescription, decimal productPrice, string mainImageUrl, Guid categoryId, CancellationToken cancellationToken)
        {
            if (await _productRepository.IsExistByNameAsync(productName))
                return Result<ProductDto>.Failure($"Product already exists by name {productName}.");

            try
            {
                var name = Name.Create(productName);
                var description = ProductDescription.Create(productDescription);
                var price = Money.Create(productPrice);
                var url = Image.Create(mainImageUrl);

                var product = Product.Create(productName, productDescription, productPrice, url, categoryId);
                await _unitOfWork.CommitAsync();

                return Result<ProductDto>.Success(ProductMapper.MapToDto(product));
            }
            catch (InvalidNameException ex)
            {
                await _unitOfWork.RollbackAsync();
                return Result<ProductDto>.Failure($"Invalid product Name {ex.Message}");
            }
            catch (InvalidProductDescriptionException ex)
            {
                await _unitOfWork.RollbackAsync();
                return Result<ProductDto>.Failure($"Invalid product Description {ex.Message}");
            }
            catch (InvalidMoneyAmountException ex)
            {
                await _unitOfWork.RollbackAsync();
                return Result<ProductDto>.Failure($"Invalid product Money Amount {ex.Message}");
            }
            catch (InvalidUrlException ex)
            {
                await _unitOfWork.RollbackAsync();
                return Result<ProductDto>.Failure($"Invalid product Main Image URL {ex.Message}");
            }
        }
        public async Task<Result<ProductVariantDto>> AddProductVariantAsync(Guid productId, string colorName, string colorHexCode, string productSize, int productQuantity, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product is null)
                return Result<ProductVariantDto>.Failure($"Product with this id({productId}) doesn't exists");

            try
            {
                var color = ProductColor.Create(colorName, colorHexCode);
                var size = ProductSize.Create(productSize);

                var variant = product.AddVariant(color, size, productQuantity);
                await _unitOfWork.CommitAsync();

                return Result<ProductVariantDto>.Success(ProductVariantMapper.MapToDto(variant));
            }
            catch(InvalidProductColorNameException ex)
            {
                await _unitOfWork.RollbackAsync();
                return Result<ProductVariantDto>.Failure($"Invalid Color Name : {ex.Message}");
            }
            catch (InvalidProductColorHexCodeException ex)
            {
                await _unitOfWork.RollbackAsync();
                return Result<ProductVariantDto>.Failure($"Invalid Color Hex Code : {ex.Message}");
            }
            catch(DomainException ex) 
            {
                await _unitOfWork.RollbackAsync();
                return Result<ProductVariantDto>.Failure($"Domain exception : {ex.Message}");
            }
        }
        public async Task<Result<ProductVariantDto>> UpdateProductVariantQuantityAsync(Guid productVariantId, int newQuantity, CancellationToken cancellationToken)
        {
            var productVariant = await _productRepository.GetProductVariantByIdAsync(productVariantId, cancellationToken);
            if (productVariant is null)
                return Result<ProductVariantDto>.Failure($"Product with this id({productVariantId}) doesn't exists");

            try
            {
                productVariant.UpdateQuantity(newQuantity);
                await _unitOfWork.CommitAsync();

                return Result<ProductVariantDto>.Success(ProductVariantMapper.MapToDto(productVariant));
            }
            catch(DomainException ex)
            {
                await _unitOfWork.RollbackAsync();
                return Result<ProductVariantDto>.Failure($"Domain exception : {ex.Message}");
            }
        }
        public async Task<Result<ProductDto>> GetProductByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product is null)
                return Result<ProductDto>.Failure($"Product with this id({id}) doesn't exists");
            
            return Result<ProductDto>.Success(ProductMapper.MapToDto(product));
        }
    }
}
