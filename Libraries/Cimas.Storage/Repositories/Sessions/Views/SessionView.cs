using System;

namespace Cimas.Storage.Repositories.Sessions.Views
{
    public class SessionView
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public string FilmName { get; set; }

        public int TicketPrice { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
