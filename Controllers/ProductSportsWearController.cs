using Microsoft.AspNetCore.Mvc;
using Web_Ban_Giay_Asp_Net_Core.Entities;
using Web_Ban_Giay_Asp_Net_Core.Models;
using Web_Ban_Giay_Asp_Net_Core.Services.Interface;
using Web_Ban_Giay_Asp_Net_Core.Services.Util;

namespace Web_Ban_Giay_Asp_Net_Core.Controllers
{
    [Route("api/product-sports-wear/")]
    [ApiController]
    public class ProductSportsWearController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductSportsWearController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Lấy danh sách sản phẩm là ĐỒ THỂ THAO có tên liên quan đến từ khóa do user nhập vào 
        [HttpGet("ds-do-the-thao")]
        public IActionResult GetListProductOfTypeByName([FromQuery] string name, [FromQuery] int quantity)
        {
            try
            {
                if (string.IsNullOrEmpty(name) || quantity <= 0) return BadRequest();

                var data = _productRepository.GetListProductOfTypeByName((int)TypeProductEnum.DO_THE_THAO, name, quantity);

                if (data == null || data.Count == 0) return NotFound();

                return Ok(new Response<List<ProductModel_Part2>>(data));

            }
            catch
            {
                return StatusCode(500);
            }
        }


    }
}
