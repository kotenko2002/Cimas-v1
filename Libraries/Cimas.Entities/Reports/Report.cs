using Cimas.Entities.WorkDays;
using Cimas.Сommon.Enums;

namespace Cimas.Entities.Reports
{
    public class Report : BaseEntity
    {
        public int WorkDayId { get; set; }
        public WorkDay WorkDay { get; set; }

        public RepostStatus Status { get; set; }
    }
}
