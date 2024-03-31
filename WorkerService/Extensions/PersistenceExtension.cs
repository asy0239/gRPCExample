using Application.Persistences;
using Domain.MessageBus.Connection;
using RedisLibrary;
using IConfiguration = Domain.MessageBus.Connection.IConfiguration;
namespace WorkerService.Extensions
{
    public static class PersistenceExtension
    {
        public static IServiceCollection AddQueue(this IServiceCollection services)
        {
            services.AddSingleton(GetConfiguration());
            services.AddSingleton<IMessageQueue, RedisService>();
            return services;
        }
        public static IRedisConfiguration GetConfiguration()
        {
            IAddress address = new Address("localhost", "6389");
            IRedisConfiguration redisConfig = new RedisConfiguration(address, "test-queue");
            return redisConfig;
        }
    }
}
