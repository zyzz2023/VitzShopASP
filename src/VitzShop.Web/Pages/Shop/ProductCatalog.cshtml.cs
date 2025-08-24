using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using VitzShop.Application.Services;
using VitzShop.Application.DTOs;

public class ProductCatalogModel : PageModel
{
    private readonly ProductService _productService;
    private readonly CategoryService _categoriesService;
    private readonly ILogger<ProductCatalogModel> _logger;
    public ProductCatalogModel(ProductService productService, CategoryService categoriesService, ILogger<ProductCatalogModel> logger)
    {
        _productService = productService;
        _categoriesService = categoriesService;
        _logger = logger;
    }

    [FromRoute]
    public string? Gender { get; set; }

    public IEnumerable<CategoryDto> CategoriesDto { get; set; } = new();
    public IEnumerable<ProductDto> ProductsDto { get; set; } = new();
    public int SelectedCategoryId { get; set; }

    public async Task OnGetAsync()
    {
        var result = await _categoriesService.GetAllAsync(HttpContext.RequestAborted);

        if (!result.IsSuccess)
        {
            _logger.LogWarning("Ошибка при получении категорий: {Error}", result.Error);
            return;
        }

        CategoriesDto = result.Value!;

        var genderLower = Gender.ToLower();
        foreach (var category in CategoriesDto)
        {
            var productsInCategory = await _productService.GetProductsByCategoryAndGenderAsync(category.Id, genderLower);
            if (productsInCategory.Any())
            {
                SelectedCategoryId = category.Id;
                ProductsDto = productsInCategory;
                break;
            }
        }

        if (!ProductsDto.Any())
        {
            SelectedCategoryId = CategoriesDto.First().Id;
        }
    }
}
