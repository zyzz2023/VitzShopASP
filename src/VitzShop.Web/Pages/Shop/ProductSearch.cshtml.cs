using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VitzShop.Application.Services;
using VitzShop.Application.DTOs;

public class ProductSearchModel : PageModel
{
    private readonly ProductService _productService;
    private readonly ILogger<ProductCatalogCategoryModel> _logger;
    public ProductSearchModel(ProductService productService, ILogger<ProductCatalogCategoryModel> logger)
    {
        _productService = productService;
        _logger = logger;
    }

    [BindProperty(SupportsGet = true)]
    public string Search { get; set; }

    public IEnumerable<ProductDto> ProductsDto { get; set; }

    public async Task OnGetAsync()
    {
        if (!string.IsNullOrWhiteSpace(Search))
        {
            Console.WriteLine($"Поиск: {Search}");
            var result = await _productService.SearchProductsAsync(Search, HttpContext.RequestAborted);

            if (!result.IsSuccess)
            {
                _logger.LogWarning("Ошибка поиска: {Error}", result.Error);
                return;
            }

            ProductsDto = result.Value!;
        }
        else
        {
            Console.WriteLine("Пустой запрос.");
            ProductsDto = new List<ProductDto>();
        }
    }
}