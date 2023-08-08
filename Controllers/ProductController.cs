using Microsoft.AspNetCore.Mvc;
using Web_Ban_Giay_Asp_Net_Core.Services.Interface;

namespace Web_Ban_Giay_Asp_Net_Core.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Lấy thông tin sản phẩm theo id
        [HttpGet("products/{id}")]
        public IActionResult GetProductById(long id)
        {
            try
            {
                var data = _productRepository.GetProductById(id);

                if (data == null)
                {
                    return NotFound(); // không tìm thấy tài nguyên trên hệ thống 
                }
                else
                {
                    return Ok(data); // trả về dữ liệu dạng Json
                }
            }
            catch
            {
                return StatusCode(500); // lỗi ở phía Server 
            }
        }

        // lấy danh sách sản phẩm có tên liên quan đến từ khóa do user nhập vào 
        [HttpGet("products/name-product")]
        public IActionResult GetListProductByName([FromQuery] string name, [FromQuery] int quantity)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    return NotFound("Keyword must not be empty.");
                }

                if (quantity <= 0)
                {
                    return BadRequest("Quantity must be a positive number.");
                }

                var data = _productRepository.GetListProductByName(name, quantity);
                if (data == null || data.Count == 0)
                {
                    return NotFound("No products found matching the provided keyword.");
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred on the server.");
            }
        }

    }
}
