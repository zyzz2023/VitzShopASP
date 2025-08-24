using Microsoft.AspNetCore.Mvc.RazorPages;

public class LayoutModel : PageModel
{
    private readonly ILogger<LayoutModel> _logger;
    public LayoutModel(ILogger<LayoutModel> logger) 
    {
        _logger = logger;
    }

}
