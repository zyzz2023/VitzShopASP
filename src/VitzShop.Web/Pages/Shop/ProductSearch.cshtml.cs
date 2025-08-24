using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VitzShop.Application.Services;
using VitzShop.Core.Entities;
using VitzShop.Domain.Entities;
using VitzShop.Infrastructure.Services;

public class ProductSearchModel : PageModel
{
    private readonly ProductService _productService;

    public ProductSearchModel(ProductService productService)
    {
        _productService = productService;
    }

    [BindProperty(SupportsGet = true)]
    public string? Search { get; set; }

    public List<Product>? Results { get; set; }

    public async Task OnGetAsync()
    {
        if (!string.IsNullOrWhiteSpace(Search))
        {
            Console.WriteLine($"Поиск: {Search}");
            Results = await _productService.SearchProductsAsync(Search);
        }
        else
        {
            Console.WriteLine("Пустой запрос.");
            Results = new List<Product>();
        }
    }
}