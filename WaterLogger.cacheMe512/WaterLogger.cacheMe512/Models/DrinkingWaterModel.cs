using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WaterLogger.cacheMe512.Models;

public class DrinkingWaterModel
{
    public int Id { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd-MMM-yy}", ApplyFormatInEditMode = true)]
    public DateTime Date { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    [Range(0, 999.99, ErrorMessage = "Value for {0} must be between 0 and 999.99")]
    public decimal Quantity { get; set; }
}
