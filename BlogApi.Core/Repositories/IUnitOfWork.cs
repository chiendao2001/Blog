using System;
using System.Threading.Tasks;
using BlogApi.Core.Repositories;

namespace BlogApi.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBlogRepository Blogs { get; }
        IUserRepository Users { get; }
        ICommentRepository Comments { get; }
        int CommitAsync();
    }
}