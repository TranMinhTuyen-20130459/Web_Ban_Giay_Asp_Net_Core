namespace Web_Ban_Giay_Asp_Net_Core.Entities.Config
{
    public class MyDbContext : DbContext
    {

        private static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            builder.AddFilter(DbLoggerCategory.Database.Name, LogLevel.Information);
            builder.AddConsole();
        });

        public DbSet<Admin> Admins { get; set; }

        public DbSet<User> Users { get; set; }

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

        public DbSet<HistoryUpdateProduct> HistoryUpdateProducts { get; set; }

        public DbSet<StatusOrder> StatusOrders { get; set; }

        public DbSet<StatusPayment> StatusPayments { get; set; }

        public DbSet<MethodPayment> MethodPayments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            const string connectionString = "Server=roundhouse.proxy.rlwy.net;Database=thuong_mai_dien_tu;User=root;Password=OPfHujkALTcykkkWMFAghntAqaoduEnF;Port=57995";
            //const string connectionString = "Server=127.0.0.1;Database=asp_net_core_web_ban_giay;User=root;Password=;";
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

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
                .WithMany(product => product.list_size)
                .HasForeignKey(sp => sp.id_product)
                .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình quan hệ nhiều-một từ SizeProduct tới Size
            modelBuilder.Entity<SizeProduct>()
                .HasOne(sp => sp.size)
                .WithMany(size => size.size_products)
                .HasForeignKey(sp => sp.name_size)
                .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình quan hệ nhiều-một từ OrderDetail tới Order
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.order)
                .WithMany(order => order.list_order_details)
                .HasForeignKey(od => od.id_order)
                .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình quan hệ nhiều-một từ OrderDetail tới Product
            modelBuilder.Entity<OrderDetail>()
             .HasOne(od => od.product)
             .WithMany(product => product.list_order_detail)
             .HasForeignKey(od => od.id_product)
             .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình khóa ngoại giữa HistoryPriceProduct và Product
            modelBuilder.Entity<HistoryPriceProduct>()
                .HasOne(hpp => hpp.product)                     // Khóa ngoại từ HistoryPriceProduct
                .WithMany(product => product.list_history_price)                // Tham chiếu đến ICollection<HistoryPriceProduct> trong Product
                .HasForeignKey(hpp => hpp.id_product)           // Khóa ngoại là id_product trong HistoryPriceProduct
                .OnDelete(DeleteBehavior.Cascade);          // Xóa các lịch sử giá liên quan khi xóa sản phẩm

            // Cấu hình khóa ngoại giữa ImageProduct và Product
            modelBuilder.Entity<ImageProduct>()
                .HasOne(imgProduct => imgProduct.product)
                .WithMany(product => product.list_image)
                .HasForeignKey(imgProduct => imgProduct.id_product)
                .OnDelete(DeleteBehavior.Cascade);

            // thiết lập constraint cho các thuộc tính của Admin
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasIndex(a => a.email).IsUnique();
            });

            // thiết lập constraint cho các thuộc tính của User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(u => u.email).IsUnique();
            });

            // Cấu hình khóa ngoại giữa HistoryUpdateProduct và Product
            modelBuilder.Entity<HistoryUpdateProduct>()
                 .HasOne(h_u_p => h_u_p.product)
                 .WithMany(p => p.list_history_update)
                 .HasForeignKey(h_u_p => h_u_p.id_product)
                 .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình khóa ngoại giữa Order và StatusOrder
            modelBuilder.Entity<Order>()
                .HasOne(o => o.status_order)
                .WithMany(s_o => s_o.list_order)
                .HasForeignKey(o => o.id_status_order)
                .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình khóa ngoại giữa Order và StatusPayment
            modelBuilder.Entity<Order>()
                .HasOne(o => o.status_payment)
                .WithMany(s_p => s_p.list_order)
                .HasForeignKey(o => o.id_status_payment)
                .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình khóa ngoại giữa Order và MethodPayment
            modelBuilder.Entity<Order>()
                .HasOne(o => o.method_payment)
                .WithMany(m_p => m_p.list_order)
                .HasForeignKey(o => o.id_method_payment)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
