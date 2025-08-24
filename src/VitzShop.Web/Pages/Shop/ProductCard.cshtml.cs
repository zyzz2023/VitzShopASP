using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VitzShop.Application.Services;
using VitzShop.Core.Entities;
using VitzShop.Domain.Entities;
using VitzShop.Infrastructure.Services;

public class ProductCardModel : PageModel
{
    private readonly ProductService _productService;

    public ProductCardModel(ProductService productService)
    {
        _productService = productService;
    }

    [FromRoute]
    public int Id { get; set; }

    public Product? Product { get; private set; }

    public async Task OnGetAsync()
    {
        Product = await _productService.GetProductByIdAsync(Id);
    }
}
