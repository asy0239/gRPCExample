using StackExchange.Redis;
using System.Data.Common;
using System.Text.Json;

namespace RedisLibrary
{
    public class RedisConnection
    {
        private string _ip { get; }
        private string _port { get; }
        private string _queueName { get; }
        private IDatabase _database { get; }

        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        public RedisConnection(string ip, string port, string queueName)
        {
            _ip = ip;
            _port = port;
            _queueName = queueName;

            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect($"{ip}:{port}");
            _database = redis.GetDatabase();
        }

        public bool StringSet(string key, string value)
        {
            return _database.StringSet(key, value);
        }

        public IList<string> GetAllItems()
        {
            var redisValues = _database.ListRange(_queueName, 0, -1);
            var result = redisValues.Select(x => x.ToString()).ToList();
            return result;
        }
        public bool JsonSet(string key, object value)
        {
            string json = JsonSerializer.Serialize(value, _jsonSerializerOptions);
            return _database.StringSet(key, json);
        }

        public T JsonGet<T>(string key)
        {
            RedisValue redisValue = _database.StringGet(key);
            if (redisValue.IsNullOrEmpty)
            {
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(redisValue, _jsonSerializerOptions);
        }
    }
}