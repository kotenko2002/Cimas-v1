using System;

namespace Cimas.Service.Sessions.Descriptors
{
    public class AddSessionDescriptor
    {
        public int FilmId { get; set; }
        public int HallId { get; set; }

        public int TicketPrice { get; set; }
        public DateTime StartDateTime { get; set; }
    }
}
