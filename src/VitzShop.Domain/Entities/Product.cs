using System.ComponentModel.DataAnnotations;
using VitzShop.Domain.Common;
using VitzShop.Domain.Exceptions;
using VitzShop.Domain.Repository;
using VitzShop.Domain.ValueObjects;

namespace VitzShop.Domain.Entities
{
    public class Product : BaseEntity<Guid>, IAggregateRoot
    {
        public Name Name { get; private set; }
        public ProductDescription Description { get; private set; }
        public Money Price { get; private set; }

        //public Guid MainImageId { get; private set; }
        //public Image MainImage { get; private set; }
        public Image MainImage { get; private set; }

        public Guid CategoryId { get; private set; }
        //public Category Category { get; private set; }

        private readonly List<ProductVariant> _variants = new();
        public IReadOnlyCollection<ProductVariant> Variants => _variants.AsReadOnly();
        
        private Product() { }

        public static Product Create(
            string productName,
            string productDescription,
            decimal productPrice,
            Image productMainImage,
            Guid categoryId)
        {
            return new Product
            {
                Name = Name.Create(productName),
                Description = ProductDescription.Create(productDescription),
                Price = Money.Create(productPrice),
                MainImage = productMainImage,
                CategoryId = categoryId
            };
        }
        public ProductVariant AddVariant(ProductColor color, ProductSize size, int quantity)
        {
            if (_variants.Any(v => v.Color == color && v.Size == size))
                throw new DomainException("Variant is already exist");

            var _variant = ProductVariant.Create(color, size, quantity, Id); // Метод с добавлением Id текущей сущности (проверить)
            _variants.Add(_variant);

            return _variant;
        }
        public void UpdateVariantQuantity(ProductColor color, ProductSize size, int newQuantity)
        {
            var _variant = _variants.FirstOrDefault(v => v.Color == color && v.Size == size);

            if (_variant == null)
                throw new DomainException("Variant not found");

            _variant.UpdateQuantity(newQuantity);

            return _variant;
        }
        public bool IsInStock() => GetTotalQuantity() > 0;
        public void UpdateMainImage(Image newImage) => MainImage = newImage;
        public int GetTotalQuantity() => _variants.Sum(v => v.Quantity);
    }
}
