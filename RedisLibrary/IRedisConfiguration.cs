using Application.MessageBus.Connection;
using Domain.MessageBus.Connection;
using StackExchange.Redis;

namespace RedisLibrary
{
    public interface IRedisConfiguration : IConfiguration
    {
        string QueueName { get; set; }
        string Get();
        ConnectionMultiplexer GetConnection();
    }
}
