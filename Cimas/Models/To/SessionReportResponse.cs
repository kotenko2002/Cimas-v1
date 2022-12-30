namespace Cimas.Models.To
{
    public class SessionReportResponse
    {
        public int Id { get; set; }
        public string FilmName { get; set; }
        public decimal Price { get; set; }
        public int SoldTickets { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
    }
}
