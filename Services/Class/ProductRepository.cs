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

        public List<ProductModel_Ver2> GetListProductOfTypeByName(int id_type, string keyword, int quantity)
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
                                           (p.id_status_product != (int)StatusProductEnum.KHONG_DUOC_BAN));
            }
            else
            {
                baseQuery = baseQuery.Where(p =>
                                           (p.type_product.id_type == id_type) &&
                                           (p.name_product.Contains(keyword)) &&
                                           (p.id_status_product != (int)StatusProductEnum.KHONG_DUOC_BAN));
            }

            var queryResult = baseQuery.OrderByDescending(p => p.time_created)
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
                var listProductModel = queryResult.Select(product => new ProductModel_Ver2
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

        public List<ProductModel_Ver2> GetListProductByTypeAndStatus(int id_type, int id_status, int page, int pageSize)
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
                var listProductModel = queryResult.Select(product => new ProductModel_Ver2
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

        public List<ProductModel_Ver2> GetListProductBy_TypeAndBrandAndSex(int id_type, int id_brand, int id_sex, int page, int pageSize)
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
                (p.id_status_product != (int)StatusProductEnum.KHONG_DUOC_BAN)
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
                var productModel = queryResult.Select(product => new ProductModel_Ver2
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
                (p.id_status_product != (int)StatusProductEnum.KHONG_DUOC_BAN)
                );

            return queryResult.Count();
        }

        public long? CreateProduct(ProductModel_Ver3 productModel)
        {
            /*
             * - Thêm sản phẩm vào bảng products
             * - Thêm ds hình ảnh sản phẩm vào bảng image_products
             * - Thêm ds size sản phẩm vào bảng size_products
             * - Thêm giá của sản phẩm vào bảng history_price_products
             */

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var productEntity = new Product
                    {
                        name_product = productModel.name_product,
                        star_review = productModel.star_review,
                        listed_price = productModel.listed_price,
                        promotional_price = productModel.promotional_price,
                        // Tìm đối tượng TypeProduct tương ứng với id_type
                        type_product = _dbContext.TypeProducts.Find(productModel.id_type),
                        // Tìm đối tượng Brand tương ứng với id_brand
                        brand = _dbContext.Brands.Find(productModel.id_brand),
                        id_sex = productModel.id_sex,
                        id_status_product = productModel.id_status_product
                    };

                    // thêm sản phẩm vào bảng products
                    _dbContext.Products.Add(productEntity);
                    _dbContext.SaveChanges();

                    long id_product = productEntity.id_product;

                    // thêm ds hình ảnh sản phẩm vào bảng image_products
                    foreach (var imgProductModel in productModel.list_image)
                    {
                        var imgProductEntity = new ImageProduct
                        {
                            path = imgProductModel.path_image,
                            id_product = id_product
                        };
                        _dbContext.ImageProducts.Add(imgProductEntity);
                    }

                    // thêm ds size của sản phẩm vào bảng size_products
                    foreach (var sizeProductModel in productModel.list_size)
                    {
                        var sizeProductEntity = new SizeProduct
                        {
                            id_product = id_product,
                            name_size = sizeProductModel.name_size,
                            quantity_available = sizeProductModel.quantity_available
                        };
                        _dbContext.SizeProducts.Add(sizeProductEntity);
                    }

                    // thêm giá của sản phẩm vào bảng history_price_products
                    var historyPriceProductEntity = new HistoryPriceProduct
                    {
                        id_product = id_product,
                        listed_price = productModel.listed_price,
                        promotional_price = productModel.promotional_price,
                        time_start = DateTime.Now
                    };
                    _dbContext.HistoryPriceProducts.Add(historyPriceProductEntity);

                    _dbContext.SaveChanges();
                    transaction.Commit();

                    return id_product;
                }
                catch
                {
                    transaction.Rollback();
                    return null;
                }
            }
        }

        public bool UpdateProduct(ProductModel_Ver4 productModel)
        {
            /*
             * cập nhật lại các field trong bảng products
             * cập nhật lại ds size của sản phẩm nếu list_size trong body Json không bằng null
             * cập nhật lại ds image của sản phẩm nếu list_image trong body Json không bằng null 
             * thêm bản ghi vào bảng history_price_products nếu giá thay đổi
             * thêm bản ghi vào bảng history_update_products
             */
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    List<SizeProductModel>? list_size_model = productModel.list_size;
                    List<ImageProductModel>? list_image_model = productModel.list_image;

                    var productEntity = _dbContext.Products
                                                   .Include(p => p.list_history_price)
                                                   .Include(p => p.list_history_update)
                                                   .Include(p => p.list_image)
                                                   .Include(p => p.list_size)
                                                   .Include(p => p.type_product)
                                                   .Include(p => p.brand)
                                                   .SingleOrDefault(p => p.id_product == productModel.id_product);

                    if (productEntity == null)
                    {
                        // Không tìm thấy sản phẩm với ID đã cung cấp
                        return false;
                    }

                    // Cập nhật ds size của sản phẩm 
                    if (list_size_model != null && list_size_model.Count > 0)
                    {
                        productEntity.list_size = list_size_model.Select(size => new SizeProduct
                        {
                            id_product = productModel.id_product,
                            name_size = size.name_size,
                            quantity_available = size.quantity_available
                        }).ToList();
                    }

                    // Cập nhật ds image của sản phẩm
                    if (list_image_model != null && list_image_model.Count > 0)
                    {
                        productEntity.list_image = list_image_model.Select(img => new ImageProduct
                        {
                            id_product = productModel.id_product,
                            id_image = (long)img.id_image,
                            path = img.path_image
                        }).ToList();
                    }

                    // Kiểm tra xem có sự thay đổi trong giá sản phẩm
                    if (productEntity.listed_price != productModel.listed_price ||
                        productEntity.promotional_price != productModel.promotional_price)
                    {
                        // Cập nhật giá trước khi thêm lịch sử giá
                        productEntity.listed_price = productModel.listed_price;
                        productEntity.promotional_price = productModel.promotional_price;

                        // Thêm một bản ghi mới vào bảng history_price_products
                        var historyPrice = new HistoryPriceProduct
                        {
                            id_product = productModel.id_product,
                            listed_price = productModel.listed_price,
                            promotional_price = productModel.promotional_price,
                            time_start = DateTime.Now
                        };
                        _dbContext.HistoryPriceProducts.Add(historyPrice);
                    }

                    productEntity.name_product = productModel.name_product;
                    productEntity.star_review = productModel.star_review;
                    productEntity.id_sex = productModel.id_sex;
                    productEntity.id_status_product = productModel.id_status_product;

                    // Lấy lại thông tin TypeProduct và Brand từ cơ sở dữ liệu dựa trên id_type và id_brand
                    var typeProduct = _dbContext.TypeProducts.SingleOrDefault(t => t.id_type == productModel.id_type);
                    var brand = _dbContext.Brands.SingleOrDefault(b => b.id_brand == productModel.id_brand);

                    if (typeProduct != null)
                    {
                        productEntity.type_product = typeProduct;
                    }

                    if (brand != null)
                    {
                        productEntity.brand = brand;
                    }

                    // thêm một bản ghi mới vào bảng history_update_products
                    var historyUpdate = new HistoryUpdateProduct
                    {
                        id_product = productModel.id_product,
                        time_updated = DateTime.Now
                    };
                    _dbContext.HistoryUpdateProducts.Add(historyUpdate);

                    // Lưu thay đổi vào cơ sở dữ liệu
                    _dbContext.SaveChanges();
                    transaction.Commit();

                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool DeleteProduct(ProductModel_Ver5 productModel)
        {
            //=> Cập nhật trạng thái của sản phẩm thành KHONG_DUOC_BAN
            try
            {
                var productEntity = _dbContext.Products.Find(productModel.id_product);//=> lấy ra sản phẩm dựa vào khóa chính (id_product)
                if (productEntity == null)
                {
                    // Không tìm thấy sản phẩm với ID đã cung cấp
                    return false;
                }

                productEntity.id_status_product = (int)StatusProductEnum.KHONG_DUOC_BAN;
                _dbContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}

