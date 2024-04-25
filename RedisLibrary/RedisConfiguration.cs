using Domain.MessageBus.Connection;
using StackExchange.Redis;

namespace RedisLibrary
{
    public class RedisConfiguration : IRedisConfiguration
    {
        public string QueueName { get; set; }
        public IAddress Address { get; set; }

        public RedisConfiguration(IAddress address, string queueName)
        {
            QueueName = queueName;
            Address = address;
        }

        public string Get()
        {
            return $"{Address.HostName}:{Address.Port}";
        }

        public ConnectionMultiplexer GetConnection()
        {
            return ConnectionMultiplexer.Connect(Get());
        }
    }
}
