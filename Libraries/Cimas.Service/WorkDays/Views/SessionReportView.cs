using System;

namespace Cimas.Service.WorkDays.Views
{
    public class SessionReportView
    {
        public int Id { get; set; }
        public string FilmName { get; set; }
        public decimal Price { get; set; }
        public int SoldTickets { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
