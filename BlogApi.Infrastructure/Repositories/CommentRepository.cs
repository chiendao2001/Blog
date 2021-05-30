using System;
using BlogApi.Core.Models;
using BlogApi.Core.Repositories;

namespace BlogApi.Infrastructure.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(BlogApiDbContext context)
            : base(context)
        { }
    }
}
