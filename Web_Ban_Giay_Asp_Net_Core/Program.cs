using dotenv.net;
using Serilog;
using Web_Ban_Giay_Asp_Net_Core.Extensions;
using Web_Ban_Giay_Asp_Net_Core.Services.Class;
using Web_Ban_Giay_Asp_Net_Core.Services.Interface;
using Log = Serilog.Log;

// The initial "bootstrap" logger is able to log errors during start-up. It's completely replaced by the
// logger configured in `AddSerilog()` below, once configuration and dependency-injection have both been
// set up successfully.
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up!");

try
{
    DotEnv.Load(options: new DotEnvOptions(probeForEnv: true)); // Tải các biến môi trường từ file .env

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllers();
    builder.Services.AddHttpContextAccessor();

    // DbContext là một class trong Entity Framework Core, nó chịu trách nhiệm quản lý kết nối đến cơ sở dữ liệu, thực hiện các thao tác CRUD (Create, Read, Update, Delete) với cơ sở dữ liệu.
    builder.Services.AddDbContext<MyDbContext>();

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

    builder.Services.ConfigureJWT(builder.Configuration);

    builder.Services.ConfigureSwagger();

    builder.Services.AddScoped<IProductRepository, ProductRepository>();
    builder.Services.AddScoped<IOrderRepository, OrderRepository>();
    builder.Services.AddScoped<IHistoryOrderRepository, HistoryOrderRepository>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IAdminRepository, AdminRepository>();
    builder.Services.AddScoped<IAuthentication, AuthenticationService>();
    builder.Services.AddScoped<ICheckExistRepository, CheckExistRepository>();

    builder.Services.AddScoped<JWTHelper>();

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

    app.UseExceptionMiddleware();

    app.UseRouting();

    app.UseCors("MyCors");

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

    Log.Information("Stopped cleanly");
    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, ex.Message);
    return 1;
}
finally
{
    Log.CloseAndFlush();
}
