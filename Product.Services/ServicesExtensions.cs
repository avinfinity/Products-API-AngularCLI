using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Services
{
    public static class ServicesExtensions
    {
        public static IServiceCollection RegisterProductServices(this IServiceCollection services)
        {
            services.AddAutoMapper(c => c.AddProfile<AutoMapperProfile>(), typeof(ServicesExtensions));
            services.AddScoped<IProductQuerySvc, ProductQuerySvc>();
            services.AddScoped<IProductCommandsSvc, ProductCommandsSvc>();

            return services;
        }
    }
}