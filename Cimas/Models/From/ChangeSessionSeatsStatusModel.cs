using Cimas.Сommon.Enums;

namespace Cimas.Models.From
{
    public class ChangeSessionSeatsStatusModel
    {
        public int SessionId { get; set; }
        public ChangeSessionSeatStatusModel[] Seats { get; set; }
    }
}
