using System.Runtime.InteropServices;
using VitzShop.Domain.Common;
using VitzShop.Domain.Exceptions;
using VitzShop.Domain.ValueObjects;
using VitzShop.Domain.Repository;

namespace VitzShop.Domain.Entities
{
    public class Category : BaseEntity<Guid>, IAggregateRoot
    {
        public Name Name { get; private set; }
        public Url ImageUrl { get; private set; }
        public Gender Gender { get; private set; }

        //private readonly List<Product> _products = new();
        //public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

        private Category() { }

        public static Category Create(Name name, Url imageUrl, Gender gender)
        {
            return new Category 
            {  
                Name = name, 
                ImageUrl = imageUrl,
                Gender = gender
            };
        }
        public void ChangeCategoryName(Name newCategoryName) => Name = newCategoryName;
        public void ChangeImageUrl(Url imageUrl) => ImageUrl = imageUrl;
    }
}
