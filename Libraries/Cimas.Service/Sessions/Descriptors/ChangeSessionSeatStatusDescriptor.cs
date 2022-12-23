using Cimas.Сommon.Enums;

namespace Cimas.Service.Sessions.Descriptors
{
    public class ChangeSessionSeatStatusDescriptor
    {
        public int Id { get; set; }
        public SeatStatus Status { get; set; }
    }
}
