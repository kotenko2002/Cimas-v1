namespace Cimas.Service.Products.Descriptors
{
    public class EditProductDescriptor
    {
        public int Id { get; set; }
        public decimal Price { get; set; }

        public int Amount { get; set; }
        public int SoldAmount { get; set; }
        public int Incoming { get; set; }
    }
}
