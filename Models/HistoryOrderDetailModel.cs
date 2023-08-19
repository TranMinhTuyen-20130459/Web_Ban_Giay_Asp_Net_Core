namespace Web_Ban_Giay_Asp_Net_Core.Models
{
    public class HistoryOrderDetailModel
    {
        public HistoryOrderModel? infor_order { get; set; }

        public List<OrderDetailModel_Ver2>? order_details { get; set; }

        public decimal? order_value { get; set; }
        public decimal? ship_price { get; set; }
        public decimal? total_price { get; set; }
    }
}
