using Cimas.Сommon.Enums;
using System;

namespace Cimas.Service.WorkDays.Views
{
    public class FullReportView
    {
        public int Id { get; set; }
        public string CinemaName { get; set; }
        public string CinemaAdress { get; set; }
        public string WorkerName { get; set; }
        public decimal Profit { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public RepostStatus Status { get; set; }
    }
}
