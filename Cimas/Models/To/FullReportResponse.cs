using Cimas.Service.WorkDays.Views;
using Cimas.Сommon.Enums;
using System.Collections.Generic;

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
        public IEnumerable<ProductResponse> Products { get; set; }
        public IEnumerable<SessionReportResponse> Sessions { get; set; }
    }
}
