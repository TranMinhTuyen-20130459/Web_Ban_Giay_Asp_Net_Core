namespace Web_Ban_Giay_Asp_Net_Core.Controllers
{
    [Route("api/products/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Trả về Json thông tin chi tiết sản phẩm
        [HttpGet("infor-product")]
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

        // Trả về Json danh sách sản phẩm có tên liên quan đến từ khóa do user nhập vào 
        [HttpGet("ds-san-pham")]
        public IActionResult GetListProductByName([FromQuery] string name, [FromQuery] int quantity)
        {
            try
            {
                if (string.IsNullOrEmpty(name) || quantity <= 0) return BadRequest();

                var data = _productRepository.GetListProductOfTypeByName(-9999, name, quantity);

                if (data == null || data.Count == 0)
                {
                    return NotFound();
                }

                return Ok(new Response<List<ProductModel_Ver2>>(data));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        // Thêm một sản phẩm vào hệ thống và trả về id của sản phẩm được thêm
        [Authorize]
        [HttpPost("create-product")]
        public IActionResult CreateProduct([FromBody] ProductModel_Ver3 productModel)
        {

            try
            {
                if (!ModelState.IsValid) return BadRequest(productModel);

                var id_product = _productRepository.CreateProduct(productModel);

                if (id_product == null)
                {
                    var errorResponse = new ErrorResponse
                    {
                        status = 500,
                        error_code = "-1",
                        error_message = "Id Product is null"
                    };

                    return StatusCode(500, errorResponse); // không thêm được sản phẩm vào hệ thống
                }

                return StatusCode(201, new { id_product }); // thêm sản phẩm thành công vào hệ thống
            }
            catch
            {

                var errorResponse = new ErrorResponse
                {
                    status = 500,
                    error_code = "-2",
                    error_message = "Error From Server"
                };

                return StatusCode(500, errorResponse); // không thêm được sản phẩm vào hệ thống do lỗi từ Server
            }
        }

        // Cập nhật thông tin của sản phẩm và trả về kết quả true or false
        [Authorize]
        [HttpPut("update-product")]
        public IActionResult UpdateProduct([FromBody] ProductModel_Ver4 productModel)
        {
            try
            {
                if (!ModelState.IsValid) { return BadRequest(productModel); }

                var checkUpdate = _productRepository.UpdateProduct(productModel);

                return Ok(new { status_update = checkUpdate });

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
    }
}
