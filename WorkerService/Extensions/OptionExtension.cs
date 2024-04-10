using Application.Option;
using Infrastructure.Data.Options;
using Microsoft.Extensions.Options;
using RabbitMQLibrary;

namespace WorkerService.Extensions
{
    public static class OptionExtension
    {
        public static IServiceCollection AddOptionExtension(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddOption<RabbitMQOptions>(configuration);
            return services;
        }

        private static IServiceCollection AddOption<T>(this IServiceCollection services, IConfigurationRoot configuration) where T : class, new()
        {
            var section = configuration.GetSection(typeof(T).Name);
            if (section == null)
                return services;
            services.Configure<T>(section);
            services.AddTransient<IOptional<T>>(provider =>
            {
                var options = provider.GetService<IOptionsMonitor<T>>()!;
                return new Optional<T>(options, configuration, section.Key, "appsettings.json");
            });

            return services;
        }
    }
}
