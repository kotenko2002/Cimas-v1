namespace Cimas.Models.From
{
    public class AddProductModel
    {
        public int WorkDayId { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Amount { get; set; }
        public string SoldAmount { get; set; }
        public string Incoming { get; set; }
    }
}
