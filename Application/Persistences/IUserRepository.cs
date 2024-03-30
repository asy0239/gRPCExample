using Domain.Entities;

namespace Application.Persistences
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User entity, CancellationToken cancellationToken = default);
        Task<User> UpdateUesrAsync(User entity, CancellationToken cancellationToken = default);
        Task<bool> DeleteUserAsync(User entity, CancellationToken cancellationToken = default);
        Task<User> GetUserAsync(long id, CancellationToken cancellationToken = default);

        User CreateUser(User entity, CancellationToken cancellationToken = default);
        User UpdateUesr(User entity, CancellationToken cancellationToken = default);
        bool DeleteUser(User entity, CancellationToken cancellationToken = default);
        User GetUser(long id, CancellationToken cancellationToken = default);
    }
}
