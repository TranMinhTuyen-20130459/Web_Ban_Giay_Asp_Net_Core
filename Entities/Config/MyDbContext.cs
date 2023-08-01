using Microsoft.EntityFrameworkCore;

namespace Web_Ban_Giay_Asp_Net_Core.Entities.Config
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<HistoryPriceProduct> HistoryPriceProducts { get; set; }

        public DbSet<ImageProduct> ImageProducts { get; set; }

        public DbSet<Log> Logs { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<PriceRange> PriceRanges { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<RoleDetail> RoleDetails { get; set; }

        public DbSet<Size> Sizes { get; set; }

        public DbSet<SizeProduct> SizeProducts { get; set; }

        public DbSet<TypeProduct> TypeProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình khóa chính cho Entity RoleDetail
            modelBuilder.Entity<RoleDetail>()
                .HasKey(rd => new { rd.id_admin, rd.id_role });

            // Cấu hình quan hệ nhiều-một từ RoleDetail tới Admin
            modelBuilder.Entity<RoleDetail>()
                .HasOne(rd => rd.admin)
                .WithMany(admin => admin.role_details) // Tên của ICollection trong Admin
                .HasForeignKey(rd => rd.id_admin)
                .OnDelete(DeleteBehavior.Cascade); // Tùy chọn này để xóa các RoleDetail liên quan khi Admin bị xóa

            // Cấu hình quan hệ nhiều-một từ RoleDetail tới Role
            modelBuilder.Entity<RoleDetail>()
                .HasOne(rd => rd.role)
                .WithMany(r => r.role_details) // Tên của ICollection trong Role
                .HasForeignKey(rd => rd.id_role)
                .OnDelete(DeleteBehavior.Cascade); // Tùy chọn này để xóa các RoleDetail liên quan khi Role bị xóa

            // Cấu hình khóa chính cho Entity SizeProduct
            modelBuilder.Entity<SizeProduct>()
                .HasKey(sp => new { sp.id_product, sp.name_size });

            // Cấu hình quan hệ nhiều-một từ SizeProduct tới Product
            modelBuilder.Entity<SizeProduct>()
                .HasOne(sp => sp.product)
                .WithMany(product => product.size_products)
                .HasForeignKey(sp => sp.id_product)
                .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình quan hệ nhiều-một từ SizeProduct tới Size
            modelBuilder.Entity<SizeProduct>()
                .HasOne(sp => sp.size)
                .WithMany(size => size.size_products)
                .HasForeignKey(sp => sp.name_size)
                .OnDelete(DeleteBehavior.Cascade);


            // Cấu hình khóa chính cho Entity OrderDetail
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.id_order, od.id_product });

            // Cấu hình quan hệ nhiều-một từ OrderDetail tới Order
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.order)
                .WithMany(order => order.list_order_details)
                .HasForeignKey(od => od.id_order)
                .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình quan hệ nhiều-một từ OrderDetail tới Product
            modelBuilder.Entity<OrderDetail>()
             .HasOne(od => od.product)
             .WithMany(product => product.order_details)
             .HasForeignKey(od => od.id_product)
             .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình khóa ngoại giữa HistoryPriceProduct và Product
            modelBuilder.Entity<HistoryPriceProduct>()
                .HasOne(hpp => hpp.product)                     // Khóa ngoại từ HistoryPriceProduct
                .WithMany(product => product.list_price)                // Tham chiếu đến ICollection<HistoryPriceProduct> trong Product
                .HasForeignKey(hpp => hpp.id_product)           // Khóa ngoại là id_product trong HistoryPriceProduct
                .OnDelete(DeleteBehavior.Cascade);          // Xóa các lịch sử giá liên quan khi xóa sản phẩm

            // Cấu hình khóa ngoại giữa ImageProduct và Product
            modelBuilder.Entity<ImageProduct>()
                .HasOne(imgProduct => imgProduct.product)
                .WithMany(product => product.images)
                .HasForeignKey(imgProduct => imgProduct.id_product)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
