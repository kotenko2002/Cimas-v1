using Cimas.Entities.Films;
using Cimas.Entities.Halls;
using System;
using System.Collections.Generic;

namespace Cimas.Entities.Sessions
{
    public class Session : BaseEntity
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }

        public int HallId { get; set; }
        public Hall Hall { get; set; }

        public int TicketPrice { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public virtual ICollection<SessionSeat> SessionSeats { get; set; }
    }
}
