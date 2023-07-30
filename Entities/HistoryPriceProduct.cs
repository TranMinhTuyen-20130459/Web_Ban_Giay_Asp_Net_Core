namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    public class HistoryPriceProduct
    {
        public int id_price_product { get; set; }

        public Product product { get; set; }

        public decimal listed_price { get; set; }

        public decimal promotional_price { get; set; }

        public DateTime time_start { get; set; }

        public DateTime time_end { get; set; }

        public DateTime create_at { get; set; }
    }
}
