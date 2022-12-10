using Cimas.Сommon.Enums;

namespace Cimas.Models.From
{
    public class ChangeSessionSeatStatusModel
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public SeatStatus Status { get; set; }
    }
}
