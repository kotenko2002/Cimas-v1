namespace Cimas.Models.To
{
    public class ProductResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }

        public int Amount { get; set; }
        public int SoldAmount { get; set; }
        public int Incoming { get; set; }

        public bool Changed { get; set; } = false;
    }
}
