using Cimas.Entities.Companies;
using System.ComponentModel.DataAnnotations;

namespace Cimas.Entities.Areas
{
    public class Area : BaseEntity
    {
        public int CompanyId { get; set; }

        [Required]
        public string Name { get; set; }
        
        public virtual Company Company { get; set; }
    }
}
