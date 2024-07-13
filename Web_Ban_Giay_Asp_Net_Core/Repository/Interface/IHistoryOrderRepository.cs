namespace Web_Ban_Giay_Asp_Net_Core.Repository.Interface
{
    public interface IHistoryOrderRepository
    {
        // lấy ra danh sách đơn hàng đã mua theo số điện thoại (có phân trang) rồi trả về model
        List<HistoryOrderModel> GetListOrderByPhoneNumber(string phoneNumber, int page, int pageSize);

        // lấy ra số lượng đơn hàng đã mua theo số điện thoại
        int GetOrderCountByPhoneNumber(string phoneNumber);

    }
}
