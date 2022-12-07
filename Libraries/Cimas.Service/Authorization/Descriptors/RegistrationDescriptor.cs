using Cimas.Сommon.Enums;

namespace Cimas.Service.Authorization.Descriptors
{
    public class RegistrationDescriptor
    {
        public int CompanyId { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
    }
}
