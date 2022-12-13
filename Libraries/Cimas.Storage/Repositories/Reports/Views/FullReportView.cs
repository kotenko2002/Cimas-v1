using Cimas.Сommon.Enums;
using System;

namespace Cimas.Storage.Repositories.Reports.Views
{
    public class FullReportView
    {
        public int Id { get; set; }
        public int WorkDayId { get; set; }
        public string WorkerName { get; set; }
        public Role WorkerRole { get; set; }
        public decimal Profit { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public RepostStatus Status { get; set; }
    }
}
