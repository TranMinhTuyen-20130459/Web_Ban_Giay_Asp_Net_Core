var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1.1", new() { Title = "Web_Ban_Giay_API", Version = "v1.1" });
    s.SwaggerDoc("v1.2", new() { Title = "Web_Ban_Giay_API", Version = "v1.2" });
    //s.DocInclusionPredicate((docName, apiDesc) => true); // Bật cho phép tất cả các API được tài liệu hóa
});

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


builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IHistoryOrderRepository, HistoryOrderRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

var app = builder.Build();

/*
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
*/

app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1.1/swagger.json", "Web_Ban_Giay_API v1.1");
    s.SwaggerEndpoint("/swagger/v1.2/swagger.json", "Web_Ban_Giay_API v1.2");
});

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("MyCors");

app.UseAuthorization();

app.MapControllers();

app.Run();

