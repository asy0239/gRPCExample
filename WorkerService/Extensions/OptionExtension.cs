using LanguageExt;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService.Extensions
{
    public static class OptionExtension
    {
        public static IServiceCollection AddOptionExtension(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddOption<MessageBusOptions>(configuration);
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
