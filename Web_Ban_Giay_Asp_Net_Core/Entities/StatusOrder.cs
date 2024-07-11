namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    public enum StatusOrderEnum
    {
        CHO_XAC_NHAN = 1,
        DA_XAC_NHAN = 2,
        CHO_LAY_HANG = 3,
        DANG_GIAO_HANG = 4,
        DA_GIAO_HANG = 5,
        TRA_HANG = 6,
        HUY_DON_HANG = 7
    }
    [Table("Status_Orders")]
    public class StatusOrder
    {
        [Key]
        public int id_status_order { get; set; }
        public string? name_status { get; set; }
        public ICollection<Order> list_order { get; set; }
    }
}
