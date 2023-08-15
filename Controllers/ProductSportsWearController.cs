﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetListSportsWearByName([FromQuery] string name, [FromQuery] int quantity)
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

        // Lấy danh sách sản phẩm là loại ĐỒ THỂ THAO có trạng thái là MỚI
        [HttpGet("ds-do-the-thao-moi")]

        public IActionResult GetListSportsWearHaveStatusNew([FromQuery] int page, [FromQuery] int pageSize)
        {
            try
            {
                var validFilter = new PaginationFilter(page, pageSize);

                var pagedData = _productRepository.GetListProductByTypeAndStatus((int)TypeProductEnum.DO_THE_THAO, (int)StatusProduct.MOI, validFilter.current_page, validFilter.page_size);

                if (pagedData == null || pagedData.Count == 0) { return NotFound(); }

                var totalItems = _productRepository.GetProductCountOfTypeAndStatus((int)TypeProductEnum.DO_THE_THAO, (int)StatusProduct.MOI);

                return Ok(new PagedResponse<List<ProductModel_Part2>>(pagedData, validFilter.current_page, validFilter.page_size, totalItems));

            }
            catch
            {
                return StatusCode(500);
            }
        }

        // Lấy danh sách sản phẩm là loại ĐỒ THỂ THAO có trạng thái là HOT
        [HttpGet("ds-do-the-thao-hot")]

        public IActionResult GetListSportsWearHaveStatusHOT([FromQuery] int page, [FromQuery] int pageSize)
        {
            try
            {
                var validFilter = new PaginationFilter(page, pageSize);

                var pagedData = _productRepository.GetListProductByTypeAndStatus((int)TypeProductEnum.DO_THE_THAO, (int)StatusProduct.HOT, validFilter.current_page, validFilter.page_size);

                if (pagedData == null || pagedData.Count == 0) { return NotFound(); }

                var totalItems = _productRepository.GetProductCountOfTypeAndStatus((int)TypeProductEnum.DO_THE_THAO, (int)StatusProduct.HOT);

                return Ok(new PagedResponse<List<ProductModel_Part2>>(pagedData, validFilter.current_page, validFilter.page_size, totalItems));

            }
            catch
            {
                return StatusCode(500);
            }
        }


        // Lấy danh sách sản phẩm là loại ĐỒ THỂ THAO có trạng thái là KHUYEN_MAI
        [HttpGet("ds-do-the-thao-khuyen_mai")]

        public IActionResult GetListSportsWearHaveStatusPromotional([FromQuery] int page, [FromQuery] int pageSize)
        {
            try
            {
                var validFilter = new PaginationFilter(page, pageSize);

                var pagedData = _productRepository.GetListProductByTypeAndStatus((int)TypeProductEnum.DO_THE_THAO, (int)StatusProduct.KHUYEN_MAI, validFilter.current_page, validFilter.page_size);

                if (pagedData == null || pagedData.Count == 0) { return NotFound(); }

                var totalItems = _productRepository.GetProductCountOfTypeAndStatus((int)TypeProductEnum.DO_THE_THAO, (int)StatusProduct.KHUYEN_MAI);

                return Ok(new PagedResponse<List<ProductModel_Part2>>(pagedData, validFilter.current_page, validFilter.page_size, totalItems));

            }
            catch
            {
                return StatusCode(500);
            }
        }


    }
}