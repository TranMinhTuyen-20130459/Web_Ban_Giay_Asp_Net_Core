using Web_Ban_Giay_Asp_Net_Core.Models;

namespace Web_Ban_Giay_Asp_Net_Core.Services.Interface
{
    public interface IOrderRepository
    {
        // tạo đơn hàng mới rồi trả về id của đơn hàng được tạo
        long? CreateOrder(OrderModel orderModel);

        // lấy ra thông tin chi tiết đơn hàng theo id đơn hàng 
        HistoryOrderDetailModel GetOrderDetailByIdOrder(long id_order);
    }
}
