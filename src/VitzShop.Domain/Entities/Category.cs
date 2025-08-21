using System.Runtime.InteropServices;
using VitzShop.Domain.Common;
using VitzShop.Domain.Exceptions;
using VitzShop.Domain.ValueObjects;

namespace VitzShop.Domain.Entities
{
    public class Category : BaseEntity<Guid>
    {
        public Name Name { get; private set; }
        public Url ImageUrl { get; private set; }

        private readonly List<Product> _products = new();
        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

        private Category() { }

        public static Category Create(Name name, Url imageUrl)
        {
            return new Category 
            {  
                Name = name, 
                ImageUrl = imageUrl 
            };
        }
        public void ChangeCategoryName(Name newCategoryName) => Name = newCategoryName;
        public void ChangeImageUrl(Url imageUrl) => ImageUrl = imageUrl;
    }
}
