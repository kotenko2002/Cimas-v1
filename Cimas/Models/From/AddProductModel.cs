using System.ComponentModel.DataAnnotations;

namespace Cimas.Models.From
{
    public class AddProductModel
    {
        [Required]
        public int? WorkDayId { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Product Name can't be more than 20 characters")]
        public string Name { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Price can't be a negative number")]
        public decimal Price { get; set; }
    }
}
