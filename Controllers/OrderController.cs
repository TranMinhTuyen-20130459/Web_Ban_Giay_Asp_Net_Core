using Microsoft.AspNetCore.Mvc;
using Web_Ban_Giay_Asp_Net_Core.Models;
using Web_Ban_Giay_Asp_Net_Core.Services.Interface;

namespace Web_Ban_Giay_Asp_Net_Core.Controllers
{
    [Route("api/order/")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost("create-order")]
        public IActionResult CreateOrder([FromBody] OrderModel orderModel)
        {
            // Kiểm tra tính hợp lệ của dữ liệu
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var id_order = _orderRepository.CreateOrder(orderModel);

                if (id_order == null) return StatusCode(500); // không tạo được đơn hàng

                // Trả về mã trạng thái 201 (Created) cùng với id_order
                return StatusCode(201, new { id_order });
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
