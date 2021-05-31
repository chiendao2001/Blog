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
        public async Task<IActionResult> GetAllComments()
        {
            try
            {
                var comments = await _commentService.GetAllComments();
                if (comments != null)
                {
                    var commentResources = _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentResource>>(comments);
                    return Ok(commentResources);
                }
                return Ok($"No comments yet");
            }
            catch
            {
                return StatusCode(500);
            }
           
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            try
            {
                var comment = await _commentService.GetCommentById(id);
                if (comment != null)
                {
                    var commentResources = _mapper.Map<Comment, CommentResource>(comment);
                    return Ok(commentResources);
                }
                return Ok($"No comment with Id {id}");
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Comment comment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _commentService.CreateComment(comment);
                    return StatusCode(201);
                }
                return StatusCode(400);
            }
            catch
            {
                return StatusCode(500);
            }

        }

        // PUT api/Comment/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Comment newComment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Comment comment = await _commentService.GetCommentById(id);
                    _commentService.UpdateComment(comment, newComment);
                    return Ok($"Comment with Id {id} updated");
                }
                return StatusCode(400);
               
            }
            catch
            {
                return StatusCode(500);
            }

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Comment comment = await _commentService.GetCommentById(id);
                _commentService.DeleteComment(comment);
                return Ok($"Comment with Id {id} deleted");
            }

            catch
            {
                return StatusCode(500);
            }
        }
    }
}
