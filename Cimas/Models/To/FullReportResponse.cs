using Cimas.Сommon.Enums;

namespace Cimas.Models.To
{
    public class FullReportResponse
    {
        public int Id { get; set; }
        public string CinemaName { get; set; }
        public string CinemaAdress { get; set; }
        public string WorkerName { get; set; }
        public decimal Profit { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public RepostStatus Status { get; set; }
    }
}
