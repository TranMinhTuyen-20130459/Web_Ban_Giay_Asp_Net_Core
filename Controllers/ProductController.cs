using Microsoft.AspNetCore.Mvc;
using Web_Ban_Giay_Asp_Net_Core.Services.Interface;

namespace Web_Ban_Giay_Asp_Net_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(long id)
        {
            try
            {
                var data = _productRepository.GetProductById(id);

                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(data);
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
