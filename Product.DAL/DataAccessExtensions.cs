using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Product.DAL
{
    public static class DataAccessExtensions
    {
        public static IServiceCollection RegisterDataAcess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<ProductDBContext>(options =>
                    options.UseMySql(configuration.GetConnectionString("MySqlDBPath")));
            
            return services;
        }
    }
}