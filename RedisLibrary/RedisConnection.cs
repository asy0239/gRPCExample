using StackExchange.Redis;

namespace RedisLibrary
{
    public class RedisConnection
    {
        private string _ip { get; }
        private string _port { get; }
        private string _queueName { get; }
        private IDatabase database { get; }
        public RedisConnection(string ip, string port, string queueName)
        {
            _ip = ip;
            _port = port;
            _queueName = queueName;

            try
            {
                ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                database = redis.GetDatabase();

            }
            catch (Exception ex)
            {
                throw ex ;
            }
        }

        public void StringSet(string key, string value)
        {
            database.StringSet(key, value);
        }
    }
}