namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    [Table("History_Price_Products")]
    public class HistoryPriceProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_price_product { get; set; }

        public long id_product { get; set; }
        public Product product { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Listed price must be greater than or equal to 0.")]
        public decimal listed_price { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Promotional price must be greater than or equal to 0.")]
        public decimal promotional_price { get; set; }

        public DateTime? time_start { get; set; }

        public DateTime? time_end { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("DateTime.Now")]
        public DateTime create_at { get; set; }
    }
}
