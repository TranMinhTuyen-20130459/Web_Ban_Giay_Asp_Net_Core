namespace Web_Ban_Giay_Asp_Net_Core.Models
{
    /*
     * Đây là Model tương ứng với chuỗi Json dành cho thông tin chi tiết của một đơn hàng 
     */
    public class HistoryOrderDetailModel
    {
        public HistoryOrderModel? infor_order { get; set; }

        public List<OrderDetailModel_Ver2>? order_details { get; set; }

        public decimal? order_value { get; set; }
        public decimal? ship_price { get; set; }
        public decimal? total_price { get; set; }
    }
}
