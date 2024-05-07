using Application.Persistences;
using Domain.MessageBus.Connection;
using Infrastructure.EFCore;
using RabbitMQLibrary;
using RedisLibrary;
using System.Reflection;

namespace WorkerService.Extensions
{
    public static class PersistenceExtension
    {
        public static IServiceCollection AddQueue(this IServiceCollection services)
        {
            services.AddSingleton(GetRedisConfiguration());
            //services.AddSingleton(GetRabbitMqConfiguration());
            //services.AddSingleton<IMessageQueue, RedisService>();
            services.AddSingleton<IMessageQueue, RabbitMQService>();
            return services;
        }
        public static IRedisConfiguration GetRedisConfiguration()
        {
            IAddress address = new Address("localhost", "6389");
            IRedisConfiguration redisConfig = new RedisConfiguration(address, "test-queue");
            return redisConfig;
        }
        public static IRabbitMQConfiguration GetRabbitMqConfiguration()
        {
            IAddress address = new Address("localhost", "5672");
            IRabbitMQConfiguration rabbitMQConfiguration = new RabbitMQConfiguration(address);

            return rabbitMQConfiguration;
        }

        public static IServiceCollection AddEFCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPostgreSql(configuration, Assembly.GetExecutingAssembly().GetName().Name!);
            return services;
        }
    }
}
