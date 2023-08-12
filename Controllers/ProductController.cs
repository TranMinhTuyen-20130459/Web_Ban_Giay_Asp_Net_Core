﻿using Microsoft.AspNetCore.Mvc;
using Web_Ban_Giay_Asp_Net_Core.Model;
using Web_Ban_Giay_Asp_Net_Core.Models;
using Web_Ban_Giay_Asp_Net_Core.Services.Interface;
using Web_Ban_Giay_Asp_Net_Core.Services.Util;

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

        // Lấy thông tin sản phẩm theo id
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

        // Lấy danh sách sản phẩm có tên liên quan đến từ khóa do user nhập vào 
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

                return Ok(new Response<List<ProductModel_Part2>>(data));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

    }
}
