using Cimas.Entities.Companies;
using Cimas.Entities.Sessions;
using System.Collections.Generic;

namespace Cimas.Entities.Films
{
    public class Film : BaseEntity
    {
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public string Name { get; set; }
        public double Duration { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
