using Library.Application.Interfaces;
using Library.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Library.API.DTOs;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Guid>> Register([FromBody] RegisterRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { message = "Invalid registration request." });
            }

            try
            {
                var userId = await _userService.RegisterUserAsync(request.Username, request.Password, request.FirstName, request.LastName, request.Email);
                return CreatedAtAction(nameof(GetUserById), new { id = userId }, new { id = userId });
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult> Authenticate([FromBody] AuthenticateRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid authentication request.");
            }

            try
            {
                var token = await _userService.GenerateJwtTokenAsync(request.Username, request.Password);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Unauthorized(new { message = ex.Message });
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers() {
            var users = await _userService.GetAllUsersAsync();
            if (users == null ) return NotFound();

            return Ok(users);   
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound(); 
            }
            return Ok(user);
        }

        // PUT: api/users/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(Guid id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest("ID mismatch."); // 400 
            }

            var result = await _userService.UpdateUserAsync(user);
            if (result)
            {
                return NoContent(); // 204
            }
            else
            {
                return NotFound(); // 404
            }
        }



        // DELETE: api/users/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (result)
            {
                return NoContent(); // 204
            }
            else
            {
                return NotFound(); 
            }
        }
    }

}
