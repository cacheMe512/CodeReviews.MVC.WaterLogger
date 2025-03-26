using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WaterLogger.cacheMe512.Models;


namespace WaterLogger.cacheMe512.Pages.DrinkingWater;

public class CreateModel : PageModel
{
    private readonly Data.WaterLoggerContext _context;

    public CreateModel(Data.WaterLoggerContext context)
    {
        _context = context;
    }

    [BindProperty]
    public DrinkingWaterModel DrinkingWaterModel { get; set; } = default!;

    public List<SelectListItem> MeasureOptions { get; set; } = new();

    public void OnGet()
    {
        MeasureOptions = Helpers.MeasureOptions.GetMeasureOptions();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            MeasureOptions = Helpers.MeasureOptions.GetMeasureOptions();
            return Page();
        }

        _context.DrinkingWaterModel.Add(DrinkingWaterModel);
        _context.SaveChanges();

        return RedirectToPage("Index");
    }
}
