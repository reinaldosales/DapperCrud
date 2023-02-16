using Domain.Interface;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace CrossCutting.IoC
{
    public static class ServiceDependency
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
