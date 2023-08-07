using Microsoft.EntityFrameworkCore;
using Web_Ban_Giay_Asp_Net_Core.Entities.Config;
using Web_Ban_Giay_Asp_Net_Core.Model;
using Web_Ban_Giay_Asp_Net_Core.Models;
using Web_Ban_Giay_Asp_Net_Core.Services.Interface;

namespace Web_Ban_Giay_Asp_Net_Core.Services.Class
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDbContext _dbContext;

        public ProductRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ProductModel GetProductById(long id)
        {
            var product = _dbContext.Products
                .Include(p => p.brand) // Eager loading cho Brand
                .Include(p => p.list_image) // Eager loading cho danh sách các hình ảnh (list_image)
                .Include(p => p.list_size)  // Eager loading cho danh sách các size sản phẩm (list_size)
                .FirstOrDefault(p => p.id_product == id);

            if (product != null)
            {
                var productModel = new ProductModel
                {
                    id_product = product.id_product,
                    name_product = product.name_product,
                    star_review = product.star_review,
                    listed_price = product.listed_price,
                    promotional_price = product.promotional_price,
                    brand = new BrandModel
                    {
                        id_brand = product.brand.id_brand,
                        name_brand = product.brand.name_brand
                    },
                    list_image = product.list_image.Select(img => new ImageProductModel
                    {
                        id_image = img.id_image,
                        path_image = img.path
                    }).ToList(),
                    list_size = product.list_size.Select(size => new SizeProductModel
                    {
                        name_size = size.name_size,
                        quantity_available = size.quantity_available
                    }).ToList()
                };

                return productModel;
            }

            return null;
        }


    }
}

