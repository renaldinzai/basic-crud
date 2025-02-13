using BasicCrud.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BasicCrud.Persistence.Postgres
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration, string defaultConfigName = "DefaultConnection")
        {
            services.AddDbContext<DataContext>(options => options.UseNpgsql(configuration.GetConnectionString(defaultConfigName)));

            services.AddScoped<IDataContext>(provider => provider.GetService<DataContext>());

            return services;
        }
    }
}
