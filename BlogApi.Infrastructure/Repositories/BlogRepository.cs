using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlogApi.Core.Models;
using BlogApi.Core.Repositories;

namespace BlogApi.Infrastructure.Repositories
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(BlogApiDbContext context)
            : base(context)
        { }

        //private BlogApiDbContext blogApiCbContext
        //{
        //    get { return _context as blogApiCbContext; }
        //}
    }
}