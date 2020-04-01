using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.DataAccess
{
    public static class DataAccessExtensions
    {
        public static IServiceCollection RegisterDataAcess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductDBContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("ConnectionPath")));
            
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}