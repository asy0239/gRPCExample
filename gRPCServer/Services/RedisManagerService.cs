using Api.Users;
using RedisLibrary;
using StackExchange.Redis;
using System.Text.Json;

namespace gRPCServer.Services
{
    public class RedisManagerService
    {
        //private IQueue _queue = default!;
        RedisConnection _connection;

        public RedisManagerService()
        {
            _connection = new RedisConnection("127.0.0.1", "6389", "InsertQueue");
        }
        public async Task Push(User user)
        {
            _connection.JsonSet(user.Id.ToString(), user);
            await Task.FromResult(0);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            //IEnumerable<User> users = _connection.JsonGet<User>("1");
            IEnumerable<User> users = new List<User>();
            return users;
        }

        public async Task<User> GetUserAsync(long key)
        {
            return _connection.JsonGet<User>(key.ToString());
        }
    }
}
