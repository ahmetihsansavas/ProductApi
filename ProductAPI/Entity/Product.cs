namespace ProductAPI.Entity
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Region { get; set; }
        public int Amount { get; set; }
        public string Sector { get; set; }
        public string CustomerName { get; set; }
        public int Units { get; set; }
        public DateTime SaleDate { get; set; }

    }
}
