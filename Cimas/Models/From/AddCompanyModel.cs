using System.ComponentModel.DataAnnotations;

namespace Cimas.Models.From
{
    public class AddCompanyModel
    {
        [Required]
        public string Name { get; set; }
    }
}
