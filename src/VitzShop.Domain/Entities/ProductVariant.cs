using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitzShop.Domain.Common;
using VitzShop.Domain.ValueObjects;
using VitzShop.Domain.Exceptions;

namespace VitzShop.Domain.Entities
{
    public class ProductVariant : BaseEntity<Guid>
    {
        public ProductColor Color { get; private set; }
        public ProductSize Size { get; private set; }
        public int Quantity { get; private set; }
        public string Sku { get; private set; }

        private readonly List<Image> _images = new();
        public IReadOnlyCollection<Image> Images => _images.AsReadOnly();

        public Guid ProductId { get; private set; }
        public Product Product { get; private set; }

        private ProductVariant() { }

        public static ProductVariant Create(ProductColor color, ProductSize size, int quantity)
        {
            var sku = GenerateSku(color, size);

            return new ProductVariant
            {
                Color = color,
                Size = size,
                Quantity = quantity,
                Sku = sku
            };

        }
        public void UpdateQuantity(int newQuantity) => Quantity = newQuantity;
        public void IncreaseQuantity(int amount)
        {
            if (amount <= 0)
                throw new DomainException("Amount must be positive");

            Quantity += amount;
        }
        public void DecreaseQuantity(int amount)
        {
            if (amount <= 0)
                throw new DomainException("Amount must be positive");
            if (Quantity < amount)
                throw new DomainException("Insufficient quantity");

            Quantity -= amount;
        }
        public void AddImage(string imageUrl, bool isMain, int displayOrder)
        {
            var _image = Image.Create(imageUrl, isMain, displayOrder);

            if(_images.Any(img => img.ImageUrl == imageUrl))
                throw new DomainException($"{imageUrl} alredy exist");

            _images.Add(_image);
        }
        public void RemoveImage(string imageUrl)
        {
            var _image = _images.FirstOrDefault(img  => img.ImageUrl == imageUrl);
            
            if(_image == null)
                throw new DomainException($"{imageUrl} not found");

            _images.Remove(_image);
        }
        //public void SetMainImage(string mainImageUrl)
        //{
        //    var _image = _images.FirstOrDefault(img => img.ImageUrl == mainImageUrl);

        //    if (_image == null)
        //        throw new DomainException($"{mainImageUrl} main image not found");

        //    foreach(var img in _images)
        //    {
        //        img.SetMain(false);
        //    }
        //    _image.SetMain(true);
        //}
        public string GetMainImageUrl()
        {
            var _image = _images.FirstOrDefault(img=> img.IsMain == true);

            if (_image == null)
                throw new DomainException("Main image not found for this variant");

            return _image.ImageUrl;
        }
        private static string GenerateSku(ProductColor color, ProductSize size)
        => $"{color.Value.Substring(0, 3).ToUpper()}-{size.Value}-{Guid.NewGuid().ToString()[..4].ToUpper()}";
    }
}
