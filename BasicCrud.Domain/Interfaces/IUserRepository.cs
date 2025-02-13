using BasicCrud.Domain.Entities;

namespace BasicCrud.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken);

        Task SaveAsync(CancellationToken cancellationToken);
    }
}
