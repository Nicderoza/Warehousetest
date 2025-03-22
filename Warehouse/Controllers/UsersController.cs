using Microsoft.AspNetCore.Mvc;
using Warehouse.Common.DTOs;
using Warehouse.Interfaces.IServices;

namespace Warehouse.WEB.Controllers
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
        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOUser>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTOUser>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult> AddUser(DTOUser user)
        {
            if (user == null)
            {
                return BadRequest("User data is null");
            }

            await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserID }, user);
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, DTOUser user)
        {
            if (id != user.UserID)
            {
                return BadRequest("User ID mismatch");
            }

            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
