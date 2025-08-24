using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VitzShop.Application.Services;
using VitzShop.Application.DTOs;
public class ProductCardModel : PageModel
{
    private readonly ProductService _productService;
    private readonly ILogger<ProductCatalogModel> _logger;
    public ProductCardModel(ProductService productService, ILogger<ProductCatalogModel> logger)
    {
        _productService = productService;
        _logger = logger;
    }

    [FromRoute]
    public Guid Id { get; set; }

    public ProductDto? ProductDto { get; private set; }

    public async Task OnGetAsync()
    {
        var result = await _productService.GetProductByIdAsync(Id, HttpContext.RequestAborted);

        if(!result.IsSuccess)
        {
            _logger.LogWarning("Ошибка при получении категорий: {Error}", result.Error);
            return;
        }

        ProductDto = result.Value!;
    }
}
