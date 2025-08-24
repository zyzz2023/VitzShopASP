using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VitzShop.Application.Services;
using VitzShop.Application.DTOs;

public class ProductCatalogCategoryModel : PageModel
{
    private readonly ProductService _productService;
    private readonly ILogger<ProductCatalogCategoryModel> _logger;
    public ProductCatalogCategoryModel(ProductService productService, ILogger<ProductCatalogCategoryModel> logger)
    {
        _productService = productService;
        _logger = logger;
    }

    [FromRoute]
    public string? Gender { get; set; }

    [FromRoute]
    public Guid ChangedCategoryId { get; set; }

    public IEnumerable<ProductDto> ProductsDto { get; set; }

    public async Task OnGetAsync()
    {
        var result = await _productService.GetProductsByCategoryIdAsync(ChangedCategoryId, HttpContext.RequestAborted);
        
        if(!result.IsSuccess)
        {
            _logger.LogWarning("Ошибка при получении категорий: {Error}", result.Error);
            return;
        }

        var products = result.Value!;

    }
}
