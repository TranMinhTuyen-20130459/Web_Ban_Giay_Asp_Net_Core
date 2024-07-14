namespace Web_Ban_Giay_Asp_Net_Core.Controllers.v1_2
{
    [Route("api/order/")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1.2")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // Tạo mới một đơn hàng
        // [Authorize]
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

                if (id_order == null) throw new Exception(); // không tạo được đơn hàng do lỗi khi thực hiện câu truy vấn

                if (id_order == -1)
                {
                    var errorResponse = new ErrorResponse
                    {
                        statusCode = 500,
                        errorMessage = "So luong san pham dat mua vuot qua so luong san pham dang con trong he thong"
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
                    statusCode = 500,
                    errorMessage = "Error From Server"
                };
                return StatusCode(500, errorResponse);
            }
        }

        // Trả về chuỗi Json thông tin chi tiết của đơn hàng 
        // [Authorize]
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

        // Trả về chuỗi Json danh sách tất cả đơn hàng đang có trong hệ thống
        [HttpGet("list-all-orders")]
        public IActionResult GetAllOrder([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] int idStatusOrder)
        {
            try
            {
                var validFilter = new PaginationFilter(page, pageSize);

                List<HistoryOrderModel>? pagedData = null;
                long totalItems = 0;

                //TH: Nếu idStatusOrder > 0 => trả về danh sách đơn hàng theo trạng thái 
                if (idStatusOrder > 0)
                {
                    pagedData = _orderRepository.GetListOrderByStatus(idStatusOrder, validFilter.current_page, validFilter.page_size);
                    totalItems = _orderRepository.CountOrdersByStatus(idStatusOrder);
                }
                //TH: Nếu idStatusOrder <= 0 => trả về danh sách tất cả các đơn hàng 
                else
                {
                    pagedData = _orderRepository.GetAllOrder(validFilter.current_page, validFilter.page_size);
                    totalItems = _orderRepository.GetCountAllOrder();
                }

                if (pagedData == null || pagedData.Count == 0) return NotFound();

                return Ok(new PagedResponse<List<HistoryOrderModel>>(pagedData, validFilter.current_page, validFilter.page_size, (int)totalItems));
            }
            catch (Exception)
            {
                var errorResponse = new ErrorResponse
                {
                    statusCode = 500,
                    errorMessage = "Error From Server"
                };
                return StatusCode(500, errorResponse);
            }
        }



    }
}
