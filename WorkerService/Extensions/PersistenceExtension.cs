using Application.Persistences;
using Domain.MessageBus.Connection;
using RabbitMQLibrary;
using RedisLibrary;
namespace WorkerService.Extensions
{
    public static class PersistenceExtension
    {
        public static IServiceCollection AddQueue(this IServiceCollection services)
        {
            services.AddSingleton(GetRedisConfiguration());
            services.AddSingleton(GetRabbitMqConfiguration());
            services.AddSingleton<IMessageQueue, RedisService>();
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
            IAddress address = new Address("localhost", "6389");
            IRabbitMQConfiguration rabbitMQConfiguration = new RabbitMQConfiguration(address);

            return rabbitMQConfiguration;
        }
    }
}
