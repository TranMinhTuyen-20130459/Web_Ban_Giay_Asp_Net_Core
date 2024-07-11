using Microsoft.Extensions.Configuration;

namespace DataTest.Config
{
    public static class ConfigUtils
    {
        public static IConfiguration GetConfiguration()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            return configBuilder.Build();
        }
    }
}
