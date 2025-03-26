using Microsoft.EntityFrameworkCore;
using WaterLogger.cacheMe512.Data;
using WaterLogger.cacheMe512.Models;

namespace WaterLogger.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new WaterLoggerContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<WaterLoggerContext>>()))
        {
            if (context == null || context.DrinkingWaterModel == null)
            {
                throw new ArgumentNullException("Null WaterLoggerContext");
            }


            if (context.DrinkingWaterModel.Any())
            {
                return;
            }

            context.DrinkingWaterModel.AddRange(
                new DrinkingWaterModel
                {
                    Date = DateTime.Parse("2025-3-25 12:15:12 PM"),
                    Quantity = 2.25M,
                    Measure = WaterMeasure.Bottles
                },
                new DrinkingWaterModel
                {
                    Date = DateTime.Parse("2025-3-24 12:15:12 PM"),
                    Quantity = 8M,
                    Measure = WaterMeasure.BigBottles
                },
                new DrinkingWaterModel
                {
                    Date = DateTime.Parse("2025-3-23 12:15:12 PM"),
                    Quantity = 5M,
                    Measure = WaterMeasure.BigBottles
                },
                new DrinkingWaterModel
                {
                    Date = DateTime.Parse("2025-3-22 12:15:12 PM"),
                    Quantity = 1.50M,
                    Measure = WaterMeasure.Glasses
                }
            );
            context.SaveChanges();
        }
    }
}
