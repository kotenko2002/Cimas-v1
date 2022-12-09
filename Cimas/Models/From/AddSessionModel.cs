using System;

namespace Cimas.Models.From
{
    public class AddSessionModel
    {
        public int FilmId { get; set; }
        public int HallId { get; set; }

        public int TicketPrice { get; set; }
        public DateTime StartDateTime { get; set; }
    }
}
