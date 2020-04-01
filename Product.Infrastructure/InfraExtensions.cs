using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Infrastructure
{
    public static class InfraExtensions
    {
        public static IServiceCollection RegisterPersistance(this IServiceCollection services)
        {
            services.AddScoped<IProductsRepository, ProductRepository>();

            return services;
        }

        public static IServiceCollection RegisterCORSPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            return services;
        }
    }
}