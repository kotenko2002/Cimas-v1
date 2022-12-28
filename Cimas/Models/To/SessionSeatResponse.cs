using Cimas.Сommon.Enums;

namespace Cimas.Models.To
{
    public class SessionSeatResponse
    {
        public int Id { get; set; }
        public int SessionId { get; set; }

        public int Row { get; set; }
        public int Column { get; set; }
        public SeatStatus Status { get; set; }

        public bool Changed { get; set; } = false;
    }
}
