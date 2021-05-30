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
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        //GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentResource>>> GetAllComments()
        {
            var comments = await _commentService.GetAllComments();
            var commentResources = _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentResource>>(comments);
            return Ok(commentResources);
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentResource>> GetBlogById(int id)
        {
            var comment = await _commentService.GetCommentById(id);
            var commentResources = _mapper.Map<Comment, CommentResource>(comment);
            return commentResources;
        }

        // POST api/values
        [HttpPost]
        public Comment Post([FromBody] Comment comment)
        {
            _commentService.CreateComment(comment);
            return comment;
        }

        // PUT api/Comment/{id}
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Comment newComment)
        {
            Comment comment = await _commentService.GetCommentById(id);
            _commentService.UpdateComment(comment, newComment);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Comment comment = await _commentService.GetCommentById(id);
            _commentService.DeleteComment(comment);
            return NoContent();
        }
    }
}
