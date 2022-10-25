using Cimas.Entities.Companies;
using System.ComponentModel.DataAnnotations;

namespace Cimas.Entities.Areas
{
    public class Area : BaseEntity<int>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

    }
}
