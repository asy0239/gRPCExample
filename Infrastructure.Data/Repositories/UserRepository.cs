using Application.Persistences;
using Domain.Entities;
using Domain.MessageBus.Connection;
using System.Reflection.Metadata;

namespace Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        IMessageQueue _queue;
        public UserRepository(IMessageQueue messageQueue)
        {
            _queue = messageQueue;
        }
        public User CreateUser(User entity, CancellationToken cancellationToken = default)
        {
            return GetUser(entity.Id, cancellationToken);
        }

        public async Task<User> CreateUserAsync(User entity, CancellationToken cancellationToken = default)
        {
            await _queue.SetValueAsync(entity.Id.ToString(), entity.Email);
            return await GetUserAsync(entity.Id, cancellationToken);
        }

        public bool DeleteUser(User entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(User entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public User GetUser(long id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserAsync(long id, CancellationToken cancellationToken = default)
        {
            var getUser = _queue.GetValueAsync(id.ToString());
            var user = new User() { Email = getUser.Result, Id = 1, Name = "asy", Password = "1234" };
            return Task.FromResult(user);
        }

        public User UpdateUesr(User entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUesrAsync(User entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
