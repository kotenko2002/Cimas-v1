using System;

namespace Cimas.Storage.Repositories.SessionSeats.Filters
{
    public class CountProfitFilter
    {
        public int CinemaId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
