using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VitzShop.Application.Services;
using VitzShop.Core.Entities;
using VitzShop.Domain.Entities;
using VitzShop.Infrastructure.Services;

public class ProductCatalogCategoryModel : PageModel
{
    private readonly ProductService _productService;

    public ProductCatalogCategoryModel(ProductService productService)
    {
        _productService = productService;
    }

    [FromRoute]
    public string? Gender { get; set; }

    [FromRoute]
    public int ChangedCategoryId { get; set; }

    public List<Product> Products { get; set; } = new();

    public async Task OnGetAsync()
    {
        if (!string.IsNullOrWhiteSpace(Gender))
        {
            var genderLower = Gender.ToLower();
            Products = await _productService.GetProductsByCategoryAndGenderAsync(ChangedCategoryId, genderLower);
        }
        else
        {
            Products = await _productService.GetProductsByCategoryIdAsync(ChangedCategoryId);
        }
    }
}
