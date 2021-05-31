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
        public async Task<IActionResult> GetAllUsers()
        {
            try {
                var users = await _userService.GetAllUsers();
                if (users != null)
                {
                    var userResources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
                    return Ok(userResources);
                }
                return Ok("No users yet");
            }

            catch
            {
                return StatusCode(500);
            }           
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserById(id);
                if (user != null)
                {
                    var userResources = _mapper.Map<User, UserResource>(user);
                    return Ok(userResources);
                }
                return Ok($"No user with Id {id}");
            }
            catch
            {
                return StatusCode(500);
            }           
        }

        // POST api/User
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            try
            {
                await _userService.CreateUser(user);
                return StatusCode(500);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // PUT api/Home/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User newUser)
        {
            try
            {
                var user = await _userService.GetUserById(id);
                _userService.UpdateUser(user, newUser);
                return Ok($"User with Id {id} updated");
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
                var user = await _userService.GetUserById(id);
                _userService.DeleteUser(user);
                return Ok($"User with Id {id} deleted");
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
