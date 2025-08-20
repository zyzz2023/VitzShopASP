using System.ComponentModel.DataAnnotations;
using VitzShop.Core.ValueObjects;
using VitzShop.Domain.Common;
using VitzShop.Domain.Exceptions;
using VitzShop.Domain.ValueObjects;

namespace VitzShop.Domain.Entities
{
    public class Product : BaseEntity<Guid>
    {
        public ProductName ProductName { get; private set; }
        public ProductDescription ProductDescription { get; private set; }
        public Money ProductPrice { get; private set; }
        public ProductImage ProductMainImage { get; private set; }

        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }

        public ProductImage MainImage { get; private set; }

        private readonly List<ProductVariant> _variants = new();
        public IReadOnlyCollection<ProductVariant> Variants => _variants.AsReadOnly();

        public static Product Create(
            string productName,
            string productDescription,
            decimal productPrice,
            ProductImage productMainImageUrl,
            Guid categoryId)
        {
            return new Product
            {
                ProductName = ProductName.Create(productName),
                ProductDescription = ProductDescription.Create(productDescription),
                ProductPrice = Money.Create(productPrice),
                ProductMainImage = productMainImageUrl,
                CategoryId = categoryId
            };
        }
        public void UpdateMainImage(ProductImage newImage) => MainImage = newImage;
        public void AddVariant(ProductColor color, ProductSize size, int quantity)
        {
            if (_variants.Any(v => v.Color == color && v.Size == size))
                throw new DomainException("Variant is already exist");

            var _variant = ProductVariant.Create(color, size, quantity);
            _variants.Add(_variant);
        }
        public void UpdateVariantQuantity(ProductColor color, ProductSize size, int newQuantity)
        {
            var _variant = _variants.FirstOrDefault(v => v.Color == color && v.Size == size);

            if (_variant == null)
                throw new DomainException("Variant not found");

            _variant.UpdateQuantity(newQuantity);
        }
        public int GetTotalQuantity() => _variants.Sum(v => v.Quantity);
        public bool IsInStock() => GetTotalQuantity() > 0;
    }
}
