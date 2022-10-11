using BlazorMap.Server.Services.Auth;
using BlazorMap.Shared.Entities;
using BlazorMap.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace BlazorMap.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLogin request)
        {
            var response = await _authService.Login(request.Email, request.Password);
            if(!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegister request)
        {
            var response = await _authService.Register(
                new User
                {
                    Email = request.Email
                }, request.Password);

            if(!response.Success)
                return BadRequest(response);
            return Ok(response);
        }
    }
}
