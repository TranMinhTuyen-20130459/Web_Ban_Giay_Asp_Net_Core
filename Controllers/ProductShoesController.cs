using Microsoft.AspNetCore.Mvc;
using Web_Ban_Giay_Asp_Net_Core.Entities;
using Web_Ban_Giay_Asp_Net_Core.Models;
using Web_Ban_Giay_Asp_Net_Core.Services.Interface;
using Web_Ban_Giay_Asp_Net_Core.Services.Util;

namespace Web_Ban_Giay_Asp_Net_Core.Controllers
{
    [Route("api/product-shoes/")]
    [ApiController]
    public class ProductShoesController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductShoesController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Lấy danh sách sản phẩm là GIÀY có tên liên quan đến từ khóa do user nhập vào 
        [HttpGet("ds-giay")]
        public IActionResult GetListShoesByName([FromQuery] string name, [FromQuery] int quantity)
        {
            try
            {
                if (string.IsNullOrEmpty(name) || quantity <= 0) return BadRequest();

                var data = _productRepository.GetListProductOfTypeByName((int)TypeProductEnum.GIAY, name, quantity);

                if (data == null || data.Count == 0) return NotFound();

                return Ok(new Response<List<ProductModel_Part2>>(data));

            }
            catch
            {
                return StatusCode(500);
            }
        }

        // Lấy danh sách sản phẩm là loại GIÀY có trạng thái là MỚI
        [HttpGet("ds-giay-moi")]
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
        [HttpGet("ds-giay-hot")]
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
        [HttpGet("ds-giay-khuyen_mai")]
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

        // Lấy danh sách sản phẩm là loại GIÀY của hãng NIKE dành cho NAM
        [HttpGet("ds-giay-nike-nam")]
        public IActionResult GetListShoesOfNikeForMen([FromQuery] int page, [FromQuery] int pageSize)
        {
            try
            {
                var validFilter = new PaginationFilter(page, pageSize);

                var pagedData = _productRepository
                                .GetListProductBy_TypeAndBrandAndSex((int)TypeProductEnum.GIAY, (int)BrandEnum.NIKE, (int)Sex.NAM,
                                validFilter.current_page, validFilter.page_size);

                if (pagedData == null || pagedData.Count == 0) return NotFound();

                int totalItems = _productRepository.GetProductCountOf_TypeAndBrandAndSex((int)TypeProductEnum.GIAY, (int)BrandEnum.NIKE, (int)Sex.NAM);

                return Ok(new PagedResponse<List<ProductModel_Part2>>(pagedData, validFilter.current_page, validFilter.page_size, totalItems));

            }
            catch
            {
                return StatusCode(500);
            }
        }

        // Lấy danh sách sản phẩm là loại GIÀY của hãng ADIDAS dành cho NAM
        [HttpGet("ds-giay-adidas-nam")]
        public IActionResult GetListShoesOfAdidasForMen([FromQuery] int page, [FromQuery] int pageSize)
        {
            try
            {
                var validFilter = new PaginationFilter(page, pageSize);

                var pagedData = _productRepository
                                .GetListProductBy_TypeAndBrandAndSex((int)TypeProductEnum.GIAY, (int)BrandEnum.ADIDAS, (int)Sex.NAM,
                                validFilter.current_page, validFilter.page_size);

                if (pagedData == null || pagedData.Count == 0) return NotFound();

                int totalItems = _productRepository.GetProductCountOf_TypeAndBrandAndSex((int)TypeProductEnum.GIAY, (int)BrandEnum.ADIDAS, (int)Sex.NAM);

                return Ok(new PagedResponse<List<ProductModel_Part2>>(pagedData, validFilter.current_page, validFilter.page_size, totalItems));

            }
            catch
            {
                return StatusCode(500);
            }
        }

        // Lấy danh sách sản phẩm là loại GIÀY của hãng JORDAN dành cho NAM
        [HttpGet("ds-giay-jordan-nam")]
        public IActionResult GetListShoesOfJordanForMen([FromQuery] int page, [FromQuery] int pageSize)
        {
            try
            {
                var validFilter = new PaginationFilter(page, pageSize);

                var pagedData = _productRepository
                                .GetListProductBy_TypeAndBrandAndSex((int)TypeProductEnum.GIAY, (int)BrandEnum.JORDAN, (int)Sex.NAM,
                                validFilter.current_page, validFilter.page_size);

                if (pagedData == null || pagedData.Count == 0) return NotFound();

                int totalItems = _productRepository.GetProductCountOf_TypeAndBrandAndSex((int)TypeProductEnum.GIAY, (int)BrandEnum.JORDAN, (int)Sex.NAM);

                return Ok(new PagedResponse<List<ProductModel_Part2>>(pagedData, validFilter.current_page, validFilter.page_size, totalItems));

            }
            catch
            {
                return StatusCode(500);
            }
        }

    }
}
