namespace Web_Ban_Giay_Asp_Net_Core.Services.Interface
{
    public interface IOrderRepository
    {
        // tạo đơn hàng mới rồi trả về id của đơn hàng được tạo
        long? CreateOrder(OrderModel orderModel);

        // lấy ra thông tin chi tiết đơn hàng theo id đơn hàng rồi trả về model
        HistoryOrderDetailModel GetOrderDetailByIdOrder(long id_order);

        // lấy ra danh sách tất cả đơn hàng đang có trong hệ thống
        List<HistoryOrderModel> GetAllOrder(int page, int pageSize);

        // lấy ra số lượng của đơn hàng đang có trong hệ thống
        long GetCountAllOrder();
    }
}
