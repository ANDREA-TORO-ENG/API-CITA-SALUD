using CitasSalud.Models;
using CitasSalud.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CitasSalud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        /// <summary>
        /// Gets a user by Id
        /// </summary>
        /// <returns>User</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        /// <summary>
        /// Creates a user
        /// </summary>
        /// <returns>User</returns>
        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser(User user)
        {
            await _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.IdUser }, user);
        }

        /// <summary>
        /// Updates a user by Id
        /// </summary>
        /// <returns>User</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, User user)
        {
            if (id != user.IdUser)
            {
                return BadRequest();
            }
            await _userService.UpdateUser(user);
            return NoContent();
        }

        /// <summary>
        /// Deletes a user by Id
        /// </summary>
        /// <returns>User</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }

        public class UserDto
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string phone { get; set; }
            public string email { get; set; }
            public DateTime dateOfBirth { get; set; }
        }

        /// <summary>
        /// Creates a user from the UI
        /// </summary>
        /// <returns>User</returns>
        [HttpPost("CreateUserUI")]


        public async Task<ActionResult> CreateUserUI([FromBody] UserDto userDto)
        {
            var user = new User
            {
                UserName = userDto.firstName,
                UserLastName = userDto.lastName,
                UserPhone = userDto.phone,
                UserEmail = userDto.email,
                UserDateBirth = userDto.dateOfBirth
            };

            await _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.IdUser }, user);
        }
    }
}
