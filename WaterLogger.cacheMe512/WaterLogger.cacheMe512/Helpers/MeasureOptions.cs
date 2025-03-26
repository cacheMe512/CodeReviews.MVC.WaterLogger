using Microsoft.AspNetCore.Mvc.Rendering;
using WaterLogger.cacheMe512.Models;

namespace WaterLogger.cacheMe512.Helpers;

public static class MeasureOptions
{
    public static List<SelectListItem> GetMeasureOptions()
    {
        return new List<SelectListItem>
        {
            new SelectListItem { Value = WaterMeasure.Glasses.ToString(), Text = "Glasses" },
            new SelectListItem { Value = WaterMeasure.Bottles.ToString(), Text = "Bottles" },
            new SelectListItem { Value = WaterMeasure.BigBottles.ToString(), Text = "Big Bottles" }
        };
    }

    public static string GetDisplayLabel(WaterMeasure measure)
    {
        return GetMeasureOptions()
            .FirstOrDefault(m => m.Value == measure.ToString())?.Text ?? measure.ToString();
    }
}
