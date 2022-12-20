using Cimas.Сommon.Enums;
using System.ComponentModel.DataAnnotations;

namespace Cimas.Models.Auth
{
    public class RegistrationModel
    {
        [Required]
        public int? CompanyId { get; set; }

        [Required, MinLength(10)]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Role? Role { get; set; }
    }
}
