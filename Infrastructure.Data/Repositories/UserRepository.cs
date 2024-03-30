using Application.Persistences;
using Domain.Entities;
using System.Reflection.Metadata;

namespace Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User CreateUser(User entity, CancellationToken cancellationToken = default)
        {
            return GetUser(entity.Id, cancellationToken);
        }

        public async Task<User> CreateUserAsync(User entity, CancellationToken cancellationToken = default)
        {
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
            return Task.FromResult(new User() { Email = "안성윤!", Id = 1, Name = "TEST", Password = "1234"});
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
