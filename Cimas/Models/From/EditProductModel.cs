namespace Cimas.Models.From
{
    public class EditProductModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }

        public string Amount { get; set; }
        public string SoldAmount { get; set; }
        public string Incoming { get; set; }
    }
}
