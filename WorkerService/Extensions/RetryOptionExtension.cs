﻿using Domain.Resilience;

namespace WorkerService.Extensions
{
    public static class RetryOptionExtension
    {
        public static IServiceCollection AddResilience(this IServiceCollection services, IConfiguration configuration)
        {
            var retryOption = new RetryOption(Convert.ToInt32(configuration.GetSection("RETRY_COUNT").Value), 10 * 1000);
            services.AddSingleton(retryOption);
            return services;
        }
    }
}
