namespace Web_Ban_Giay_Asp_Net_Core.Models
{
    /*
     * Đây là Model tương ứng với chuỗi Json dành cho thông tin cơ bản của một đơn hàng 
     */
    public class HistoryOrderModel
    {
        public long id_order { get; set; }
        public string? name_customer { get; set; }
        public string? address { get; set; }
        public string? phone { get; set; }
        public DateTime time_order { get; set; }
        public int status_order { get; set; }
        public string name_status_order { get; set; }

        public HistoryOrderModel(long id_order, string? name_customer, string? to_address,
            string? to_ward_name, string? to_district_name, string? to_province_name,
            string? phone, DateTime time_order, int id_status_order)
        {
            this.id_order = id_order;
            this.name_customer = name_customer;
            this.address = GetInforAddress(to_address, to_ward_name, to_district_name, to_province_name);
            this.phone = phone;
            this.time_order = time_order;
            this.status_order = id_status_order;
            this.name_status_order = GetNameStatusOrder(id_status_order);
        }

        public string GetNameStatusOrder(int id_status_order)
        {
            switch (id_status_order)
            {
                case 1: { return "CHỜ XÁC NHẬN"; }
                case 2: { return "ĐÃ XÁC NHẬN"; }
                case 3: { return "CHỜ LẤY HÀNG"; }
                case 4: { return "ĐANG GIAO HÀNG"; }
                case 5: { return "ĐÃ GIAO HÀNG"; }
                case 6: { return "TRẢ HÀNG"; }
                case 7: { return "HỦY ĐƠN HÀNG"; }
                default: { return ""; }
            }
        }

        // Lấy thông tin địa chỉ chi tiết của đơn hàng 
        public string GetInforAddress(string? to_address, string? to_ward_name, string? to_district_name, string? to_province_name)
        {
            string formattedAddress = string.Join(", ",
                new[] { to_address, to_ward_name, to_district_name, to_province_name }
                .Where(component => !string.IsNullOrEmpty(component))
            );

            return formattedAddress;
        }

    }
}
