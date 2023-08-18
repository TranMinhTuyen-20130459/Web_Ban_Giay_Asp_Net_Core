namespace Web_Ban_Giay_Asp_Net_Core.Models
{
    public class HistoryOrderModel
    {
        public long id_order { get; set; }
        public DateTime time_order { get; set; }
        public int status_order { get; set; }
        public string name_status_order { get; set; }

        public HistoryOrderModel(long id_order, DateTime time_order, int id_status_order)
        {
            this.id_order = id_order;
            this.time_order = time_order;
            this.status_order = id_status_order;

            switch (id_status_order)
            {
                case 1: { this.name_status_order = "CHỜ XÁC NHẬN"; break; }
                case 2: { this.name_status_order = "ĐÃ XÁC NHẬN"; break; }
                case 3: { this.name_status_order = "CHỜ LẤY HÀNG"; break; }
                case 4: { this.name_status_order = "ĐANG GIAO HÀNG"; break; }
                case 5: { this.name_status_order = "ĐÃ GIAO HÀNG"; break; }
                case 6: { this.name_status_order = "TRẢ HÀNG"; break; }
                case 7: { this.name_status_order = "HỦY ĐƠN HÀNG"; break; }
                default: { this.name_status_order = ""; break; }
            }
        }
    }
}
