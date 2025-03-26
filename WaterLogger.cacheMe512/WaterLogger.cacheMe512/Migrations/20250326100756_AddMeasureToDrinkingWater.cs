using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaterLogger.cacheMe512.Migrations
{
    /// <inheritdoc />
    public partial class AddMeasureToDrinkingWater : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Measure",
                table: "DrinkingWaterModel",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Measure",
                table: "DrinkingWaterModel");
        }
    }
}
