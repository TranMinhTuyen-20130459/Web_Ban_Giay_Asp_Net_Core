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

        // Tạo mới một đơn hàng
        [Authorize]
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

                if (id_order == null) return StatusCode(500); // không tạo được đơn hàng do lỗi khi thực hiện câu truy vấn

                if (id_order == -1)
                {
                    var errorResponse = new ErrorResponse
                    {
                        status = 500,
                        error_code = "-1",
                        error_message = "So luong san pham dat mua vuot qua so luong san pham dang con trong he thong"
                    };
                    return StatusCode(500, errorResponse);
                }

                // Trả về mã trạng thái 201 (Created) cùng với id_order
                return StatusCode(201, new { id_order });
            }
            catch
            {
                var errorResponse = new ErrorResponse
                {
                    status = 500,
                    error_code = "-2",
                    error_message = "Error From Server"
                };
                return StatusCode(500, errorResponse);
            }
        }

        // Trả về chuỗi Json thông tin chi tiết của đơn hàng 
        [Authorize]
        [HttpGet("infor-order")]
        public IActionResult GetOrderDetailByIdOrder([FromQuery] long id_order)
        {
            try
            {
                if (id_order < 1) return BadRequest();

                var data = _orderRepository.GetOrderDetailByIdOrder(id_order);

                if (data == null) return NotFound();

                return Ok(new Response<HistoryOrderDetailModel>(data));

            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
