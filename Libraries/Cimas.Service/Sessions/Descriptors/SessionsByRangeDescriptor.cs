using System;

namespace Cimas.Service.Sessions.Descriptors
{
    public class SessionsByRangeDescriptor
    {
        public DateTime StartDate { get; set; }
        public int days { get; set; }
    }
}
