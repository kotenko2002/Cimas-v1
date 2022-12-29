using Cimas.Сommon.Enums;

namespace Cimas.Models.To
{
    public class ShortReportForReviewerResponse
    {
        public int Id { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public string Status { get; set; }
    }
}
