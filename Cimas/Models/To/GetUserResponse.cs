using Cimas.Сommon.Enums;

namespace Cimas.Models.To
{
    public class GetUserResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public Role Role { get; set; }
    }
}
