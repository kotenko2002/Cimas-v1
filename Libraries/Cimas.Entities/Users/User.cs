using Cimas.Entities.Areas;
using Cimas.Entities.Companies;
using Cimas.Сommon.Enums;
using System.ComponentModel.DataAnnotations;

namespace Cimas.Entities.Users
{
    public class User : BaseEntity
    {
        public int? CompanyId { get; set; }
        public int? AreaId { get; set; }

        [Required]
        public string Login { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string PasswordSalt { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Role Role { get; set; }


        public virtual Company Company { get; set; }
        public virtual Area Area { get; set; }
    }
}
