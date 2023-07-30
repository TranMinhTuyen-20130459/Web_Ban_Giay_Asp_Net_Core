namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    public class OrderDetail
    {
        public Order order { get; set; }

        public Product product { get; set; }

        public int quantity { get; set; }

        public decimal price { get; set; }
    }
}
