namespace Cimas.Models.To
{
    public class SessionResponse
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public string FilmName { get; set; }

        public int TicketPrice { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
