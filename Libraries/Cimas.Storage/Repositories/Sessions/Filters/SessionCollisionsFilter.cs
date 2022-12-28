using System;

namespace Cimas.Storage.Repositories.Sessions.Filters
{
    public class SessionCollisionsFilter
    {
        public int HallId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
