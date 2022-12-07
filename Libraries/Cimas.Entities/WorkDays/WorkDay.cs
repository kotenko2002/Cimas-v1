using Cimas.Entities.Cinemas;
using Cimas.Entities.Products;
using Cimas.Entities.Reports;
using Cimas.Entities.Users;
using System;
using System.Collections.Generic;

namespace Cimas.Entities.WorkDays
{
    public class WorkDay : BaseEntity
    {
        public int CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
