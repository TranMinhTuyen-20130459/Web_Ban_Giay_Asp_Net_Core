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

        public List<ProductModel_Part2> GetListProductOfTypeByName(int id_type, string keyword, int quantity)
        {
            if (string.IsNullOrEmpty(keyword) || quantity <= 0) return null;

            /*
             * IQueryable là một interface trong Entity Framework Core (EF Core) cho phép bạn xây dựng các truy vấn LINQ trên dữ liệu cơ sở dữ liệu mà không cần thực hiện truy vấn ngay lập tức. 
             * Thay vào đó, truy vấn chỉ tồn tại dưới dạng một chuỗi các biểu thức LINQ. 
             * Khi bạn yêu cầu dữ liệu thực sự bằng cách gọi các phương thức như ToList(), FirstOrDefault(), Count(), Sum() và những phương thức tương tự, truy vấn sẽ được biên dịch thành SQL và thực hiện trên cơ sở dữ liệu để trả về kết quả tương ứng.
             * Lợi ích của việc sử dụng IQueryable bao gồm khả năng tối ưu hóa truy vấn, sự hỗ trợ cho việc lười biếng (lazy loading), khả năng filter và projection trên cơ sở dữ liệu, tạo các truy vấn phức tạp và cải thiện hiệu suất tương tác với dữ liệu. 
             */

            IQueryable<Product> baseQuery = _dbContext.Products
                .Include(p => p.list_image);

            if (id_type == -9999) // tất cả các loại sản phẩm
            {
                baseQuery = baseQuery.Where(p =>
                                           (p.name_product.Contains(keyword)) &&
                                           (p.id_status_product != (int)StatusProduct.KHONG_DUOC_BAN));
            }
            else
            {
                baseQuery = baseQuery.Where(p =>
                                           (p.type_product.id_type == id_type) &&
                                           (p.name_product.Contains(keyword)) &&
                                           (p.id_status_product != (int)StatusProduct.KHONG_DUOC_BAN));
            }

            var queryResult = baseQuery
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
                // chuyển kết quả truy vấn sang danh sách các sản phẩm (List<ProductModel_Part2>)
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

        public List<ProductModel_Part2> GetListProductBy_TypeAndBrandAndSex(int id_type, int id_brand, int id_sex, int page, int pageSize)
        {
            if (page <= 0 || pageSize <= 0) return null;

            /*
            * IQueryable là một interface trong Entity Framework Core (EF Core) cho phép bạn xây dựng các truy vấn LINQ trên dữ liệu cơ sở dữ liệu mà không cần thực hiện truy vấn ngay lập tức. 
            * Thay vào đó, truy vấn chỉ tồn tại dưới dạng một chuỗi các biểu thức LINQ. 
            * Khi bạn yêu cầu dữ liệu thực sự bằng cách gọi các phương thức như ToList(), FirstOrDefault(), Count(), Sum() và những phương thức tương tự, truy vấn sẽ được biên dịch thành SQL và thực hiện trên cơ sở dữ liệu để trả về kết quả tương ứng.
            * Lợi ích của việc sử dụng IQueryable bao gồm khả năng tối ưu hóa truy vấn, sự hỗ trợ cho việc lười biếng (lazy loading), khả năng filter và projection trên cơ sở dữ liệu, tạo các truy vấn phức tạp và cải thiện hiệu suất tương tác với dữ liệu. 
            */

            IQueryable<Product> baseQuery = _dbContext.Products.Include(p => p.list_image);

            #region Filter
            baseQuery = baseQuery.Where(p =>
                (p.type_product.id_type == id_type) &&
                (p.brand.id_brand == id_brand) &&
                (p.id_sex == id_sex) &&
                (p.id_status_product != (int)StatusProduct.KHONG_DUOC_BAN)
                );
            #endregion

            #region Paging
            baseQuery = baseQuery.Skip((page - 1) * pageSize).Take(pageSize);
            #endregion

            var queryResult = baseQuery.Select(p => new
            {
                p.id_product,
                p.name_product,
                p.star_review,
                p.listed_price,
                p.promotional_price,
                p.list_image,
                p.id_status_product
            });

            if (queryResult != null)
            {
                // Ánh xạ kết quả từ queryResult về List<ProductModel_Part2>
                var productModel = queryResult.Select(product => new ProductModel_Part2
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

                return productModel.ToList();

                /*
                 * Tất cả mọi thứ trong biểu thức truy vấn của bạn chỉ là một lời hứa rằng "Khi tôi thực sự cần dữ liệu, tôi sẽ đi lấy nó từ cơ sở dữ liệu." 
                 * Khi bạn gọi .ToList(), bạn thực sự đang nói "Ồ, tôi muốn dữ liệu ngay bây giờ." 
                 * Khi bạn không gọi .ToList() trong queryResult, lời hứa này chưa thực sự được thực hiện, 
                 * nhưng khi bạn gọi .ToList() ở phần cuối, nó đang giữ lời hứa và thực hiện truy vấn thực sự để lấy dữ liệu từ cơ sở dữ liệu và chuyển thành danh sách thực tế.
                 */

            }

            return null;

        }

        public int GetProductCountOf_TypeAndBrandAndSex(int id_type, int id_brand, int id_sex)
        {
            var queryResult = _dbContext.Products
                .Where(p =>
                (p.type_product.id_type == id_type) &&
                (p.brand.id_brand == id_brand) &&
                (p.id_sex == id_sex) &&
                (p.id_status_product != (int)StatusProduct.KHONG_DUOC_BAN)
                );

            return queryResult.Count();
        }
    }
}

