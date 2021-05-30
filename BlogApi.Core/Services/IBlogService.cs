using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogApi.Core.Models;

namespace BlogApi.Core.Services
{
    public interface IBlogService
    {
        Task<Blog> GetBlogById(int id);
        Task<IEnumerable<Blog>> GetAllBlogs();
        Task<Blog> CreateBlog(Blog newBlog);
        void UpdateBlog(Blog blogToBeUpdated, Blog blog);
        void DeleteBlog(Blog blog);
    }
}
