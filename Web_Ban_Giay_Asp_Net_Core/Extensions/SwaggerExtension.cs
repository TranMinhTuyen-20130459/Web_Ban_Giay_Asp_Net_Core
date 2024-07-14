using Microsoft.OpenApi.Models;

namespace Web_Ban_Giay_Asp_Net_Core.Extensions
{
    public static class SwaggerExtension
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1.1", new() { Title = "Web_Ban_Giay_API", Version = "v1.1" });
                s.SwaggerDoc("v1.2", new() { Title = "Web_Ban_Giay_API", Version = "v1.2" });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Place to add JWT with Bearer",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme{
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Name = "Bearer",
                        },
                            new List<string>()
                        }
                });
            });

        }
    }
}
