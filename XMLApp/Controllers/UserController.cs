using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XMLApp.DTO;
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

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult> LogIn(LogInDTO dto)
        {
            try
            {
                if (!await _userService.EmailMatchesPasswordAsync(dto))
                {
                    return BadRequest("Log in unsuccessful!");
                }

                return Ok(await _userService.LogInUserAsync(dto));

            }
            catch (Exception ex)
            {
                return BadRequest("Log in unsuccessful!");
            }

        }

    }
}
