using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WaterLogger.cacheMe512.Models;

namespace WaterLogger.cacheMe512.Pages.DrinkingWater;

public class IndexModel : PageModel
{
    private readonly WaterLogger.cacheMe512.Data.WaterLoggerContext _context;

    public IndexModel(WaterLogger.cacheMe512.Data.WaterLoggerContext context)
    {
        _context = context;
    }

    public IList<DrinkingWaterModel> DrinkingWaterModel { get; set; } = default!;

    public async Task OnGetAsync()
    {
        DrinkingWaterModel = await _context.DrinkingWaterModel.ToListAsync();
    }
}
