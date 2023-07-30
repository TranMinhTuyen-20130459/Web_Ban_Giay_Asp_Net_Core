using Microsoft.EntityFrameworkCore;

namespace Web_Ban_Giay_Asp_Net_Core.Entities
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        public DbSet<TestTable> TestTables { get; set; }


    }
}
