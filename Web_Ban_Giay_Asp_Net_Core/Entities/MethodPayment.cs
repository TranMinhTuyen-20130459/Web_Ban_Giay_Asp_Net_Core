namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    public enum MethodPaymentEnum
    {
        Cash = 1,
        Zalo_Pay = 2,
        PayPal = 3
    }
    [Table("Method_Payments")]
    public class MethodPayment
    {
        [Key]
        public int id_method_payment { get; set; }
        public string? name_method { get; set; }
        public ICollection<Order> list_order { get; set; }
    }
}
