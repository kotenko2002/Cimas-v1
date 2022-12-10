using System;

namespace Cimas.Storage.Repositories.Sessions.Filter
{
    public class SessionsByRangeFilter
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
