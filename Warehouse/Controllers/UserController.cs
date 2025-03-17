﻿using Microsoft.AspNetCore.Mvc;
using Warehouse.Data.Models;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult> AddUser(Users user)
        {
            if (User == null)
            {
                return BadRequest("utente assente");
            }
            await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.IDUser }, user);

        }
        [HttpPut("{id}")]
         public async Task<ActionResult>UpdateUser(int id,Users user)
         {
            if (id != user.IDUser)
            {
                return BadRequest("User ID mismatch");
            }
            await _userService.UpdateUserAsync(user);
            return NoContent();
         }
        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user ==null)
            {
                return NotFound();
            }
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }


    }

}



