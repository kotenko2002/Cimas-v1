using System.ComponentModel.DataAnnotations;

namespace Cimas.Models.From
{
    public class AddFilmModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double? Duration { get; set; }
    }
}
