using Cimas.Entities.Cinemas;
using Cimas.Entities.Sessions;
using System.Collections.Generic;

namespace Cimas.Entities.Halls
{
    public class Hall : BaseEntity
    {
        public int CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }

        public string Name { get; set; }

        public virtual ICollection<HallSeat> HallSeats { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
