namespace Web_Ban_Giay_Asp_Net_Core.Controllers
{
    [Route("api/history/")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryOrderRepository _historyOrderRepository;

        public HistoryController(IHistoryOrderRepository historyOrderRepository)
        {
            _historyOrderRepository = historyOrderRepository;
        }

        // Trả về chuỗi Json danh sách đơn hàng được mua bởi số điện thoại (có phân trang)
        [Authorize]
        [HttpGet("lich-su-mua-hang")]
        public IActionResult GetListOrderByPhoneNumber([FromQuery] string phoneNumber, [FromQuery] int page, [FromQuery] int pageSize)
        {
            try
            {
                // Kiểm tra số điện thoại có đúng định dạng không
                if (!FunctionUtil.IsValidPhoneNumber(phoneNumber))
                {
                    return BadRequest();
                }

                var validFilter = new PaginationFilter(page, pageSize);

                var pagedData = _historyOrderRepository.GetListOrderByPhoneNumber(phoneNumber, validFilter.current_page, validFilter.page_size);

                if (pagedData == null || pagedData.Count == 0) return NotFound();

                var totalItems = _historyOrderRepository.GetOrderCountByPhoneNumber(phoneNumber);

                return Ok(new PagedResponse<List<HistoryOrderModel>>
                                            (pagedData, validFilter.current_page, validFilter.page_size, totalItems));

            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
