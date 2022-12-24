using System.ComponentModel.DataAnnotations;

namespace Cimas.Models.From
{
    public class StartWorkDayModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "You didn't chose any cinema")]
        public int CinemaId { get; set; }
    }
}
