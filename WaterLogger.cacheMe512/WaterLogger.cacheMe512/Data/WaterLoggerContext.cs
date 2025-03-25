using Microsoft.EntityFrameworkCore;

namespace WaterLogger.cacheMe512.Data;

public class WaterLoggerContext : DbContext
{
    public WaterLoggerContext(DbContextOptions<WaterLoggerContext> options)
        : base(options)
    {
    }

    public DbSet<WaterLogger.cacheMe512.Models.DrinkingWaterModel> DrinkingWaterModel { get; set; } = default!;
}
