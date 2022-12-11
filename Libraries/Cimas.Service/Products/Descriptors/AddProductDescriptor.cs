namespace Cimas.Service.Products.Descriptors
{
    public class AddProductDescriptor
    {
        public int WorkDayId { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Amount { get; set; }
        public string SoldAmount { get; set; }
        public string Incoming { get; set; }
    }
}
