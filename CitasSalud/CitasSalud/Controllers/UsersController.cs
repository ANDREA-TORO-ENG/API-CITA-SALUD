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
        /// Obtiene todos los usuarios
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            //IQueryable<User> usersAsQueryable = users.AsQueryable();
            //IQueryable<User> filter = usersAsQueryable.Where(e => e.UserName.Equals("Cristian"));

            return Ok(users);
        }

        /// <summary>
        /// Obtiene usuario por el Id
        /// </summary>
        /// <returns>Usuario</returns>
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
        /// Crea usuario
        /// </summary>
        /// <returns>Usuario</returns>
        [HttpPost]
        public async Task<ActionResult> CreateUser(User user)
        {
            await _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.IdUser }, user);
        }

        /// <summary>
        /// Actualiza usuario por el Id
        /// </summary>
        /// <returns>Usuario</returns>
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
        /// Elimina usuario por el Id
        /// </summary>
        /// <returns>Usuario</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
