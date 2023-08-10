using Microsoft.AspNetCore.Mvc;
using Web_Ban_Giay_Asp_Net_Core.Entities;
using Web_Ban_Giay_Asp_Net_Core.Model;
using Web_Ban_Giay_Asp_Net_Core.Models;
using Web_Ban_Giay_Asp_Net_Core.Services.Interface;
using Web_Ban_Giay_Asp_Net_Core.Services.Util;

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
        [HttpGet("products/infor-product")]
        public IActionResult GetProductById([FromQuery] long id)
        {
            try
            {
                var data = _productRepository.GetProductById(id);

                if (data == null)
                {
                    return NotFound(); // không tìm thấy tài nguyên trên hệ thống 
                }

                return Ok(new Response<ProductModel>(data)); // trả về dữ liệu dạng Json

            }
            catch
            {
                return StatusCode(500); // lỗi ở phía Server 
            }
        }

        // Lấy danh sách sản phẩm có tên liên quan đến từ khóa do user nhập vào 
        [HttpGet("products/list-product")]
        public IActionResult GetListProductByName([FromQuery] string name, [FromQuery] int quantity)
        {
            try
            {
                if (string.IsNullOrEmpty(name) || quantity <= 0) return BadRequest();

                var data = _productRepository.GetListProductByName(name, quantity);

                if (data == null || data.Count == 0)
                {
                    return NotFound();
                }

                return Ok(new Response<List<ProductModel_Part2>>(data));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        // Lấy danh sách sản phẩm là loại GIÀY có trạng thái là MỚI
        [HttpGet("/products/list-product/giay-moi")]

        public IActionResult GetListShoesHaveStatusNew([FromQuery] int page, [FromQuery] int pageSize)
        {
            try
            {
                var validFilter = new PaginationFilter(page, pageSize);

                var pagedData = _productRepository.GetListProductByTypeAndStatus((int)TypeProductEnum.GIAY, (int)StatusProduct.MOI, validFilter.current_page, validFilter.page_size);

                if (pagedData == null || pagedData.Count == 0) { return NotFound(); }

                var totalItems = _productRepository.GetProductCountOfTypeAndStatus((int)TypeProductEnum.GIAY, (int)StatusProduct.MOI);

                return Ok(new PagedResponse<List<ProductModel_Part2>>(pagedData, validFilter.current_page, validFilter.page_size, totalItems));

            }
            catch
            {
                return StatusCode(500);
            }
        }

        // Lấy danh sách sản phẩm là loại GIÀY có trạng thái là HOT
        [HttpGet("/products/list-product/giay-hot")]

        public IActionResult GetListShoesHaveStatusHOT([FromQuery] int page, [FromQuery] int pageSize)
        {
            try
            {
                var validFilter = new PaginationFilter(page, pageSize);

                var pagedData = _productRepository.GetListProductByTypeAndStatus((int)TypeProductEnum.GIAY, (int)StatusProduct.HOT, validFilter.current_page, validFilter.page_size);

                if (pagedData == null || pagedData.Count == 0) { return NotFound(); }

                var totalItems = _productRepository.GetProductCountOfTypeAndStatus((int)TypeProductEnum.GIAY, (int)StatusProduct.HOT);

                return Ok(new PagedResponse<List<ProductModel_Part2>>(pagedData, validFilter.current_page, validFilter.page_size, totalItems));

            }
            catch
            {
                return StatusCode(500);
            }
        }


        // Lấy danh sách sản phẩm là loại GIÀY có trạng thái là KHUYEN_MAI
        [HttpGet("/products/list-product/giay-khuyen_mai")]

        public IActionResult GetListShoesHaveStatusPromotional([FromQuery] int page, [FromQuery] int pageSize)
        {
            try
            {
                var validFilter = new PaginationFilter(page, pageSize);

                var pagedData = _productRepository.GetListProductByTypeAndStatus((int)TypeProductEnum.GIAY, (int)StatusProduct.KHUYEN_MAI, validFilter.current_page, validFilter.page_size);

                if (pagedData == null || pagedData.Count == 0) { return NotFound(); }

                var totalItems = _productRepository.GetProductCountOfTypeAndStatus((int)TypeProductEnum.GIAY, (int)StatusProduct.KHUYEN_MAI);

                return Ok(new PagedResponse<List<ProductModel_Part2>>(pagedData, validFilter.current_page, validFilter.page_size, totalItems));

            }
            catch
            {
                return StatusCode(500);
            }
        }




    }
}
