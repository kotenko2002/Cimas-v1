using Cimas.Сommon.Enums;

namespace Cimas.Models.From
{
    public class ChangeSessionSeatsStatusModel
    {
        public int SessionId { get; set; }

        public int Row { get; set; }
        public int Column { get; set; }
        public SeatStatus Status { get; set; }
    }
}
