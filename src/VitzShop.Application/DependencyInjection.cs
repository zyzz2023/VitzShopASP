using Microsoft.Extensions.DependencyInjection;
using VitzShop.Application.Interfaces;
using VitzShop.Application.Services;
using VitzShop.Application.Mappers;

namespace VitzShop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayerServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}
