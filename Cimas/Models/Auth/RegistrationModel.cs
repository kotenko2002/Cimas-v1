using Cimas.Сommon.Enums;
using System.ComponentModel.DataAnnotations;

namespace Cimas.Models.Auth
{
    public class RegistrationModel
    {
        public int? CompanyId { get; set; }
        public int? AreaId { get; set; }

        [MinLength(5)]
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
    }
}
