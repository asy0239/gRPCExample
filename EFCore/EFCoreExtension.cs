using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.EFCore
{
    public static class EFCoreExtension
    {
        public static IServiceCollection AddPostgreSql(this IServiceCollection services, IConfiguration configuration, string assemblyName)
        {
            services.AddDbContextFactory<ApplicationDBcontext>(option =>
            {
                var url = configuration.GetSection("PostgreSql").Value ?? configuration.GetConnectionString("PostgreSql");
                option.UseNpgsql(url,
                    b => b.MigrationsAssembly(assemblyName));
            });
            return services;
        }
    }
}
