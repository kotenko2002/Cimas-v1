using System;
using System.ComponentModel.DataAnnotations;

namespace Cimas.Models.From
{
    public class SessionsByRangeModel
    {
        [Required]
        public int? HallId { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
