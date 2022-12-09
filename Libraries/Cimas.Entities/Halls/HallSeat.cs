using Cimas.Сommon.Enums;

namespace Cimas.Entities.Halls
{
    public class HallSeat : BaseEntity
    {
        public int HallId { get; set; }
        public Hall Hall { get; set; }

        public int Row { get; set; }
        public int Column { get; set; }
    }
}
