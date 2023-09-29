using Web_Ban_Giay_Asp_Net_Core.Services.Class;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("MySQL");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

/*
 * CORS là viết tắt của "Cross-Origin Resource Sharing" (Chia sẻ tài nguyên giữa các nguồn gốc khác nhau). Đây là một cơ chế trong trình duyệt web để cho phép các trang web ở một nguồn (domain) cụ thể yêu cầu tài nguyên từ một nguồn khác mà không gặp phải vấn đề về chính sách cùng nguồn (same-origin policy).
 */
builder.Services.AddCors(c => c.AddPolicy("MyCors", build =>
{
    // build.WithOrigins("http://localhost:3000", "https://anhdev.com");
    build.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

// configure strongly typed settings object
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IHistoryOrderRepository, HistoryOrderRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
/*
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
*/

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// Custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>();

app.UseRouting();

app.UseCors("MyCors");

app.UseAuthorization();

app.MapControllers();

app.Run();

