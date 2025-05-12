using System.ComponentModel.DataAnnotations;

namespace VitzShop.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название обязательно")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "Цена должна быть больше 0")]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Количество не может быть отрицательным")]
        public int SizeM { get; set; } // M

        [Range(0, int.MaxValue, ErrorMessage = "Количество не может быть отрицательным")]
        public int SizeL { get; set; } // L

        [Range(0, int.MaxValue, ErrorMessage = "Количество не может быть отрицательным")]
        public int SizeXl { get; set; } // XL
        public string Gender {  get; set; } = string.Empty;

        // Внешний ключ
        public int CategoryId { get; set; }
        // Навигационное свойство
        public Category? Category { get; set; }

        public List<ProductImage> Images { get; set; } = new();
    }
}
