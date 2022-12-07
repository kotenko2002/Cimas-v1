using Cimas.Entities.WorkDays;
using System;
using System.Collections.Generic;

namespace Cimas.Entities.Products
{
    public class Product : BaseEntity
    {
        public int WorkDayId { get; set; }
        public WorkDay WorkDay { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Amount { get; set; }
        public string SoldAmount { get; set; }
        public string Incoming { get; set; }
    }
}
