using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using BlogApi.Api.Resources;
using BlogApi.Core.Models;
using BlogApi.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAllBlogs()
        {
            var a = new BlogResource();
            try
            {
                var blogs = await _blogService.GetAllBlogs();
                var blogResources = _mapper.Map<IEnumerable<Blog>, IEnumerable<BlogResource>>(blogs);
                if (blogResources != null)
                {
                    return Ok(blogResources);
                }
                return Ok("No blogs yet");

            }
            catch 
            {
                return StatusCode(500);
            }
        }

        // GET api/Home
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            try
            {
                var blog = await _blogService.GetBlogById(id);
                var blogResources = _mapper.Map<Blog, BlogResource>(blog);
                if (blog == null)
                {
                    return Ok($"No blog with Id {id}");
                }
                return Ok(blogResources);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Blog blog)
        {
            try
            {
                await _blogService.CreateBlog(blog);
                return StatusCode(201);
            }
            catch 
            {
                return StatusCode(500);
            }
        }

        // PUT api/Home/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Blog newBlog)
        {
            try
            {
                Blog blog = await _blogService.GetBlogById(id);
                _blogService.UpdateBlog(blog, newBlog);
                return Ok($"Blog with Id {id} updated");
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // DELETE api/Home/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Blog blog = await _blogService.GetBlogById(id);
                _blogService.DeleteBlog(blog);
                return Ok($"Blog with Id {id} deleted");
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
