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

    public IEnumerable<CategoryDto> CategoriesDto { get; set; }
    public IEnumerable<ProductDto> ProductsDto { get; set; }
    public Guid SelectedCategoryId { get; set; }

    public async Task OnGetAsync()
    {
        var result = await _categoriesService.GetAllByGenderAsync(Gender, HttpContext.RequestAborted);

        if (!result.IsSuccess)
        {
            _logger.LogWarning("Ошибка при получении категорий: {Error}", result.Error);
            return;
        }

        CategoriesDto = result.Value!;

        if (!ProductsDto.Any())
        {
            SelectedCategoryId = CategoriesDto.First().Id;
        }
    }
}
