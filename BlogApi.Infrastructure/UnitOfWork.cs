using System;
using System.Threading.Tasks;
using BlogApi.Core.Repositories;
using BlogApi.Core;
using BlogApi.Infrastructure.Repositories;

namespace BlogApi.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogApiDbContext _context;
        private BlogRepository _blogRepository;
        private UserRepository _userRepository;
        private CommentRepository _commentRepository;

        public UnitOfWork(BlogApiDbContext context)
        {
            _context = context;
        }

        public IBlogRepository Blogs => _blogRepository = _blogRepository ?? new BlogRepository(_context);

        public ICommentRepository Comments => _commentRepository = _commentRepository ?? new CommentRepository(_context);

        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);

        public int CommitAsync()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
