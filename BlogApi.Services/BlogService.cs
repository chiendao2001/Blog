using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogApi.Core;
using BlogApi.Core.Models;
using BlogApi.Core.Services;

namespace Services
{
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BlogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Blog> GetBlogById(int id)
        {
            return await _unitOfWork.Blogs.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Blog>> GetAllBlogs()
        {
            return await _unitOfWork.Blogs.GetAllAsync();
        }

        public async Task<Blog> CreateBlog(Blog blog)
        {
            await _unitOfWork.Blogs.AddAsync(blog);
            _unitOfWork.CommitAsync();
            return blog;
        }

        public void DeleteBlog(Blog blog)
        {
            _unitOfWork.Blogs.Remove(blog);
            _unitOfWork.CommitAsync();
        }

        public void UpdateBlog(Blog blogToBeUpdated, Blog blog)
        {
            blogToBeUpdated.Title = blog.Title;
            blogToBeUpdated.Content = blog.Content;
            blogToBeUpdated.UserId = blog.UserId;
            _unitOfWork.CommitAsync();
        }
    }
}
