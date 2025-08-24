using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly ILogger<ProductCatalogModel> _logger;

    public IndexModel(ILogger<ProductCatalogModel> logger)
    {
        _logger = logger;
    }
    public void OnGet()
    {
        // Никакой логики не требуется
    }
}
