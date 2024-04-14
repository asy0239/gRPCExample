using Application.Persistences;
using StackExchange.Redis;

namespace RedisLibrary
{
    public class RedisService : IMessageQueue
    {
        IRedisConfiguration _redisConfiguration;
        private IDatabase _dataBase;
        public RedisService(IRedisConfiguration configuration)
        {
            _redisConfiguration = configuration;
            _dataBase = _redisConfiguration.GetConnection().GetDatabase();
        }

        public Task<string> ConsumeMessageAsync(string queueName)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetValueAsync(string key)
        {
            return await _dataBase.StringGetAsync(key);
        }

        public Task PublishMessageAsync(string queueName, string message)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveKeyAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task SetValueAsync(string key, string value)
        {
            return _dataBase.StringSetAsync(key,value);
        }
    }
}
