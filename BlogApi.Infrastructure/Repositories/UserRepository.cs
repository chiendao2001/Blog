using BlogApi.Core.Models;
using BlogApi.Core.Repositories;

namespace BlogApi.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BlogApiDbContext context)
            : base(context)
        { }
    }
}