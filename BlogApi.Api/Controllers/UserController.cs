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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        //GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResource>>> GetAllComments()
        {
            var users = await _userService.GetAllUsers();
            var userResources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return Ok(userResources);
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResource>> GetBlogById(int id)
        {
            var user = await _userService.GetUserById(id);
            var userResources = _mapper.Map<User, UserResource>(user);
            return userResources;
        }

        // POST api/User
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            await _userService.CreateUser(user);
            return user;
        }

        // PUT api/Home/{id}
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User newUser)
        {
            var user = await _userService.GetUserById(id);
            _userService.UpdateUser(user, newUser);
        }

        // DELETE api/Home/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _userService.GetUserById(id);
            _userService.DeleteUser(user);
            return NoContent();
        }
    }
}
