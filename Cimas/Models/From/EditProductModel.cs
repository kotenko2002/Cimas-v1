using System.ComponentModel.DataAnnotations;

namespace Cimas.Models.From
{
    public class EditProductModel
    {
        [Required]
        public int? Id { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price can't be a negative number")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Sold can't be a negative number")]
        public int SoldAmount { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Incomed can't be a negative number")]
        public int Incoming { get; set; }
    }
}
