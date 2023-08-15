﻿using Web_Ban_Giay_Asp_Net_Core.Entities;
using Web_Ban_Giay_Asp_Net_Core.Entities.Config;
using Web_Ban_Giay_Asp_Net_Core.Models;
using Web_Ban_Giay_Asp_Net_Core.Services.Interface;

namespace Web_Ban_Giay_Asp_Net_Core.Services.Class
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MyDbContext _dbContext;

        public OrderRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public long? CreateOrder(OrderModel orderModel)
        {
            AddressModel addressModel = orderModel.to_address;
            List<OrderDetailModel> orderDetailModels = orderModel.list_order_detail;

            var orderEntity = new Order
            {
                from_name = "",
                from_phone = "",
                from_address = "",
                from_ward_name = "",
                from_district_name = "",
                from_province_name = "",
                from_ward_id = "",
                from_district_id = "",
                from_province_id = "",

                to_name = orderModel.name_customer,
                to_phone = orderModel.phone,
                to_address = addressModel.address,
                to_ward_name = addressModel.ward_name,
                to_district_name = addressModel.district_name,
                to_province_name = addressModel.province_name,
                to_ward_id = addressModel.ward_id,
                to_district_id = addressModel.district_id,
                to_province_id = addressModel.province_id,

                email_customer = orderModel.email_customer,
                note = orderModel.note,

                ship_price = orderModel.ship_price,
                order_value = orderModel.order_value,
                total_price = orderModel.ship_price + orderModel.order_value,

                id_status_order = (int)StatusOrder.CHO_XAC_NHAN
            };

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    // Thêm thực thể Order vào bảng Orders và lưu thay đổi để lấy ID mới
                    _dbContext.Orders.Add(orderEntity);
                    _dbContext.SaveChanges();

                    long newOrderId = orderEntity.id_order;

                    // Thêm chi tiết đơn hàng và cập nhật số lượng sản phẩm
                    foreach (var orderDetailModel in orderDetailModels)
                    {
                        // Tạo thực thể OrderDetail từ OrderDetailModel
                        var orderDetailEntity = new OrderDetail
                        {
                            id_order = newOrderId,
                            id_product = orderDetailModel.id_product,
                            name_size = orderDetailModel.name_size,
                            quantity = orderDetailModel.quantity,
                            price = orderDetailModel.price
                        };

                        // Thêm thực thể OrderDetail vào bảng OrderDetails
                        _dbContext.OrderDetails.Add(orderDetailEntity);

                        // Cập nhật số lượng sản phẩm trong bảng SizeProducts
                        var sizeProduct = _dbContext.SizeProducts
                            .FirstOrDefault(sp => sp.id_product == orderDetailModel.id_product && sp.name_size == orderDetailModel.name_size);

                        if (sizeProduct != null)
                        {
                            sizeProduct.quantity_available -= orderDetailModel.quantity;
                        }
                    }

                    // Lưu thay đổi để hoàn thành giao dịch
                    _dbContext.SaveChanges();
                    transaction.Commit();

                    // Trả về ID của đơn hàng mới
                    return newOrderId;
                }
                catch
                {
                    transaction.Rollback();
                }
            }

            return null;
        }
    }
}