using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XMLApp.DTO;
using XMLApp.Model;
using XMLApp.Services;

namespace XMLApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Authorized for: ADMIN, LIBRARIAN
        /// </summary>
        /// <returns> Confirmation for registration</returns>
        /// <response code="200">Registration successful</response>
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterDTO dto)
        {
            try
            {
                if (await _userService.CheckIfEmailExistsAsync(dto.Email))
                {
                    return Conflict("This email already exists!");
                }

                await _userService.RegisterUser(dto);
                return Ok("User registered successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest("Unsuccessful registration.");
            }

        }

    }
}
