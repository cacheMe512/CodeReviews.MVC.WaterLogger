using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WaterLogger.cacheMe512.Models;

namespace WaterLogger.cacheMe512.Pages.DrinkingWater;

public class DetailsModel : PageModel
{
    private readonly WaterLogger.cacheMe512.Data.WaterLoggerContext _context;

    public DetailsModel(WaterLogger.cacheMe512.Data.WaterLoggerContext context)
    {
        _context = context;
    }

    public DrinkingWaterModel DrinkingWaterModel { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var drinkingwatermodel = await _context.DrinkingWaterModel.FirstOrDefaultAsync(m => m.Id == id);
        if (drinkingwatermodel == null)
        {
            return NotFound();
        }
        else
        {
            DrinkingWaterModel = drinkingwatermodel;
        }
        return Page();
    }
}
