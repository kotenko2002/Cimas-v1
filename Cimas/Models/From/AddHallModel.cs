using System.ComponentModel.DataAnnotations;

namespace Cimas.Models.From
{
    public class AddHallModel
    {
        [Required]
        public int? CinemaId { get; set; }
        [Required]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Count of Rows can't be less than 1")]
        public int Rows { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Count of Columns can't be less than 1")]
        public int Columns { get; set; }
    }
}
