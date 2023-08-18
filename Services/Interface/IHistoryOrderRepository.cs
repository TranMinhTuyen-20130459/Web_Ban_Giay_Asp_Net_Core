using Web_Ban_Giay_Asp_Net_Core.Models;

namespace Web_Ban_Giay_Asp_Net_Core.Services.Interface
{
    public interface IHistoryOrderRepository
    {
        // lấy ra danh sách đơn hàng đã mua theo số điện thoại (có phân trang)
        List<HistoryOrderModel> GetListOrderByPhoneNumber(string phoneNumber, int page, int pageSize);

        // lấy ra số lượng đơn hàng đã mua theo số điện thoại
        int GetOrderCountByPhoneNumber(string phoneNumber);

        // lấy ra chi tiết đơn hàng theo id đơn hàng 
        HistoryOrderDetailModel GetOrderDetailByIdOrder(long id_order);
    }
}
