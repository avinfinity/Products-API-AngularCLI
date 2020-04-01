using Microsoft.Extensions.DependencyInjection;

namespace Product.Domain
{
    public static class DomainExtensions
    {
        public static IServiceCollection RegisterProductDomain(this IServiceCollection services)
        {
            services.AddScoped<IProductAggregateRoot, Products>();

            return services;
        }
    }
}