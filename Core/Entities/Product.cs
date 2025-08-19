using System.ComponentModel.DataAnnotations;

namespace VitzShop.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int SizeM { get; set; }
        public int SizeL { get; set; }
        public int SizeXl { get; set; }
        public string Gender { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<ProductImage> Images { get; set; } = new();
    }+
}
