using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterLogger.cacheMe512.Models;

namespace WaterLogger.cacheMe512.Pages.DrinkingWater;

public class CreateModel : PageModel
{
    private readonly WaterLogger.cacheMe512.Data.WaterLoggerContext _context;

    public CreateModel(WaterLogger.cacheMe512.Data.WaterLoggerContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public DrinkingWaterModel DrinkingWaterModel { get; set; } = default!;

    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.DrinkingWaterModel.Add(DrinkingWaterModel);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
