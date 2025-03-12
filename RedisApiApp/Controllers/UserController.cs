using Microsoft.AspNetCore.Mvc;
using RedisApiApp.Dto;
using RedisApiApp.Models;
using RedisApiApp.Service.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace RedisApiApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepositoryService _userService;

        public UserController(IUserRepositoryService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email
            };

            await _userService.AddUserASync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var users = await _userService.GetAllUsersAsync();
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
