using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WaterLogger.cacheMe512.Models;

namespace WaterLogger.cacheMe512.Pages.DrinkingWater;

public class DeleteModel : PageModel
{
    private readonly WaterLogger.cacheMe512.Data.WaterLoggerContext _context;

    public DeleteModel(WaterLogger.cacheMe512.Data.WaterLoggerContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var drinkingwatermodel = await _context.DrinkingWaterModel.FindAsync(id);
        if (drinkingwatermodel != null)
        {
            DrinkingWaterModel = drinkingwatermodel;
            _context.DrinkingWaterModel.Remove(DrinkingWaterModel);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
