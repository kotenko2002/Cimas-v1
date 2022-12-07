using Cimas.Entities.Cinemas;
using Cimas.Entities.Films;
using Cimas.Entities.Users;
using System.Collections.Generic;

namespace Cimas.Entities.Companies
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Cinema> Cinemas { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Film> Films { get; set; }
    }
}
