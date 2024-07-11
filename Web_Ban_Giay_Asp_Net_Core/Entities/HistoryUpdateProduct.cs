namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    [Table("History_Update_Products")]
    public class HistoryUpdateProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_update_product { get; set; }

        public long id_product { get; set; } //=> đây là khóa ngoại tham chiếu đến khóa chính của bảng products
        public Product product { get; set; }

        public DateTime time_updated { get; set; }
    }
}
