using Cimas.Entities.Companies;
using Cimas.Entities.Halls;
using Cimas.Entities.WorkDays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cimas.Entities.Cinemas
{
    public class Cinema : BaseEntity
    {
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public string Name { get; set; }
        public string Adress { get; set; }

        public virtual ICollection<WorkDay> WorkDays { get; set; }
        public virtual ICollection<Hall> Halls { get; set; }
    }
}
