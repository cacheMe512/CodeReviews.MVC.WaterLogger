using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WaterLogger.cacheMe512.Models;

namespace WaterLogger.cacheMe512.Pages.DrinkingWater;

public class EditModel : PageModel
{
    private readonly WaterLogger.cacheMe512.Data.WaterLoggerContext _context;

    public EditModel(WaterLogger.cacheMe512.Data.WaterLoggerContext context)
    {
        _context = context;
    }

    [BindProperty]
    public DrinkingWaterModel DrinkingWaterModel { get; set; } = default!;

    public List<SelectListItem> MeasureOptions { get; set; } = new();


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
        DrinkingWaterModel = drinkingwatermodel;
        MeasureOptions = Helpers.MeasureOptions.GetMeasureOptions();
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            MeasureOptions = Helpers.MeasureOptions.GetMeasureOptions();
            return Page();
        }

        _context.Attach(DrinkingWaterModel).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DrinkingWaterModelExists(DrinkingWaterModel.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool DrinkingWaterModelExists(int id)
    {
        return _context.DrinkingWaterModel.Any(e => e.Id == id);
    }
}
