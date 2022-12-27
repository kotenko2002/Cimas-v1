using System;
using System.ComponentModel.DataAnnotations;

namespace Cimas.Models.From
{
    public class AddSessionModel
    {
        [Required]
        public int? FilmId { get; set; }
        [Required]
        public int? HallId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "TicketPrice can't be less than 0")]
        public int TicketPrice { get; set; }
        [Required]
        public DateTime? StartDateTime { get; set; }
    }
}
