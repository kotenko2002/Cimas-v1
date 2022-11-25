using Cimas.Entities.Areas;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cimas.Entities.Companies
{
    public class Company : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Area> Areas { get; set; }
    }
}
