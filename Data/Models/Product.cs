namespace VitzShop.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty; // M, L, XL
        public string Gender {  get; set; } = string.Empty;

        // Внешний ключ
        public int CategoryId { get; set; }

        // Навигационное свойство
        public Category? Category { get; set; }
    }
}
