using Cimas.Сommon.Enums;
using System;

namespace Cimas.Storage.Repositories.Reports.Views
{
    public class ShortReportForReviewerView
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public RepostStatus Status { get; set; }
    }
}
