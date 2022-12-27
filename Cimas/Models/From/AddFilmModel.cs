using System.ComponentModel.DataAnnotations;

namespace Cimas.Models.From
{
    public class AddFilmModel
    {
        [Required]
        public string Name { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Duration can't be less than 1")]
        public double Duration { get; set; }
    }
}
