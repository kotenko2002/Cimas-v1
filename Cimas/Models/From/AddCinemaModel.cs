using System.ComponentModel.DataAnnotations;

namespace Cimas.Models.From
{
    public class AddCinemaModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Adress { get; set; }
    }
}
