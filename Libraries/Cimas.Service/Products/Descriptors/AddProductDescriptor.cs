namespace Cimas.Service.Products.Descriptors
{
    public class AddProductDescriptor
    {
        public int WorkDayId { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }

        public int Amount { get; set; }
        public int SoldAmount { get; set; }
        public int Incoming { get; set; }
    }
}
