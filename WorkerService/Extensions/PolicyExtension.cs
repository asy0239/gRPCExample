using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WorkerService.Core.Behaviors;
using WorkerService.Core.policies;

namespace WorkerService.Extensions
{
    public static class PolicyExtension
    {
        public static IServiceCollection AddPolicy(this IServiceCollection services)
        {
            services.AddTransient<PolicyFactory>();

            return services;
        }
    }
}
