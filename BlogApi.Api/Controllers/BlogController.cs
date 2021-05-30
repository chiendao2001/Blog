using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogApi.Api.Resources;
using BlogApi.Core.Models;
using BlogApi.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;

        public BlogController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        // GET: api/Home
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogResource>>> GetAllBlogs()
        {
            var blogs = await _blogService.GetAllBlogs();
            var blogResources = _mapper.Map<IEnumerable<Blog>, IEnumerable<BlogResource>>(blogs);
            return Ok(blogResources);
        }

        // GET api/Home
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogResource>> GetBlogById(int id)
        {
            var blog = await _blogService.GetBlogById(id);
            var blogResources = _mapper.Map<Blog, BlogResource>(blog);
            return blogResources;
        }

        // POST api/values
        [HttpPost]
        public Blog Post([FromBody] Blog blog)
        {
            _blogService.CreateBlog(blog);
            return blog;
        }

        // PUT api/Home/{id}
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Blog newBlog)
        {
            Blog blog = await _blogService.GetBlogById(id);
            _blogService.UpdateBlog(blog, newBlog);
        }

        // DELETE api/Home/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var blog = await _blogService.GetBlogById(id);
            _blogService.DeleteBlog(blog);
            return NoContent();
        }
    }
}
