using Microsoft.EntityFrameworkCore;
using Web_Ban_Giay_Asp_Net_Core.Entities;
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
                .Include(p => p.type_product) // Eager loading cho TypeProduct
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
                    type = new TypeProductModel
                    {
                        id_type = product.type_product.id_type,
                        name_type = product.type_product.name_type
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

        public List<ProductModel_Part2> GetListProductByName(string keyword, int quantity)
        {

            if (keyword.Length == 0 || quantity <= 0) return null;

            var queryResult = _dbContext.Products
               .Include(p => p.list_image) // Eager loading cho danh sách các hình ảnh (list_image)
               .Where(p => p.name_product.Contains(keyword) && (p.id_status_product != (int)StatusProduct.KHONG_DUOC_BAN))
               .Select(p => new
               {
                   p.id_product,
                   p.name_product,
                   p.star_review,
                   p.listed_price,
                   p.promotional_price,
                   p.list_image,
                   p.id_status_product
               }).Take(quantity).ToList(); // lấy ra quantity product (vd: lấy ra 10 sản phẩm thỏa điều kiện trên)


            if (queryResult != null)
            {
                // chuyển kết quả truy vấn sang danh sách các sản phẩm (List<ProductModel>)
                var listProductModel = queryResult.Select(product => new ProductModel_Part2
                {
                    id_product = product.id_product,
                    name_product = product.name_product,
                    star_review = product.star_review,
                    listed_price = product.listed_price,
                    promotional_price = product.promotional_price,
                    list_image = product.list_image.Select(img => new ImageProductModel
                    {
                        id_image = img.id_image,
                        path_image = img.path
                    }).ToList(),
                    id_status_product = product.id_status_product
                });
                return listProductModel.ToList();
            }

            return null;
        }

        public List<ProductModel_Part2> GetListProductByTypeAndStatus(int id_type, int id_status, int page, int pageSize)
        {

            if (page <= 0 || pageSize <= 0) return null;

            var queryResult = _dbContext.Products
                                        .Include(p => p.list_image)
                                        .Where(p => p.type_product.id_type == id_type && (p.id_status_product == id_status))
                                        .Select(p => new // Chọn các trường dữ liệu cần thiết
                                        {
                                            p.id_product,
                                            p.name_product,
                                            p.star_review,
                                            p.listed_price,
                                            p.promotional_price,
                                            p.list_image,
                                            p.id_status_product
                                        })
                                        .Skip((page - 1) * pageSize) // Bỏ qua các sản phẩm trước trang hiện tại
                                        .Take(pageSize); // Lấy số lượng sản phẩm tối đa cho trang hiện tại

            if (queryResult != null)
            {
                var listProductModel = queryResult.Select(product => new ProductModel_Part2
                {
                    id_product = product.id_product,
                    name_product = product.name_product,
                    star_review = product.star_review,
                    listed_price = product.listed_price,
                    promotional_price = product.promotional_price,
                    list_image = product.list_image.Select(img => new ImageProductModel
                    {
                        id_image = img.id_image,
                        path_image = img.path
                    }).ToList(),
                    id_status_product = product.id_status_product
                });

                return listProductModel.ToList();
            }

            return null;
        }

        public int GetProductCountOfTypeAndStatus(int id_type, int id_status)
        {
            var queryResult = _dbContext.Products.Where(p => p.type_product.id_type == id_type && (p.id_status_product == id_status));

            return queryResult.Count();
        }
    }
}

