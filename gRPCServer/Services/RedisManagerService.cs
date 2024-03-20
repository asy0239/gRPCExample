using RedisLibrary;

namespace gRPCServer.Services
{
    public class RedisManagerService
    {
        //private IQueue _queue = default!;
        RedisConnection _connection;
        public RedisManagerService()
        {
            _connection = new RedisConnection("127.0.0.1", "6379", "InsertQueue");
        }
        public async Task Push(string input)
        {
            _connection.StringSet("test","test323");
            await Task.FromResult(0);
        }
    }
}
