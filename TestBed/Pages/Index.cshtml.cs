using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using TestBed.Data; // <-- тука ставаш namespace каде што ти е DbContext
using TestBed.Models; // <-- тука ставаш namespace каде што ти е TaxiRides

namespace TestBed.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ApplicationDbContext _context;

    [BindProperty(SupportsGet = true)]
    public string Culture { get; set; } = "en";

    public List<SelectListItem> Cultures { get; }

    public List<TaxiRide> TaxiRides2 { get; set; } = new();

    public IndexModel(
        IOptions<RequestLocalizationOptions> requestLocalizationOptions,
        ILogger<IndexModel> logger,
        ApplicationDbContext context // додадено
    )
    {
        Cultures = requestLocalizationOptions
            .Value
            .SupportedCultures!
            .Select(x => new SelectListItem(x.DisplayName, x.TwoLetterISOLanguageName))
            .ToList();

        _logger = logger;
        _context = context;
    }

    public async Task OnGetAsync()
    {
        TaxiRides2 = await _context.TaxiRides2.ToListAsync(); // читање од база
    }
}
