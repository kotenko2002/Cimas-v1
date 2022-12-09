using Cimas.Сommon.Enums;

namespace Cimas.Service.Sessions.Descriptors
{
    public class ChangeSessionSeatsStatusDescriptor
    {
        public int SessionId { get; set; }

        public int Row { get; set; }
        public int Column { get; set; }
        public SeatStatus Status { get; set; }
    }
}
