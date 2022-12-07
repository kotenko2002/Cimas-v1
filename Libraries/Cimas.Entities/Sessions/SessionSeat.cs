using Cimas.Сommon.Enums;

namespace Cimas.Entities.Sessions
{
    public class SessionSeat : BaseEntity
    {
        public int SessionId { get; set; }
        public Session Session { get; set; }

        public int Row { get; set; }
        public int Column { get; set; }
        public SeatStatus Status { get; set; }
    }
}
