namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    public enum StatusPaymentEnum
    {
        CHO_THANH_TOAN = 1,
        DA_THANH_TOAN = 2
    }
    [Table("Status_Payments")]
    public class StatusPayment
    {
        [Key]
        public int id_status_payment { get; set; }
        public string? name_status { get; set; }
        public ICollection<Order> list_order { get; set; }
    }
}
