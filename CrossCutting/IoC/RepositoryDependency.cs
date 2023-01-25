using Data.Repository;
using Domain.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.IoC
{
    public static class RepositoryDependency
    {
        public static void AddRepositoryDependency(this IServiceCollection services)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
