using BasicCrud.Application.Interfaces;
using BasicCrud.Domain.Entities;
using BasicCrud.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud.Infrastructure.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataContext _dbContext;

        public UserRepository(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken)
        {
            return await _dbContext.User.Where(x => x.Username == username).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
