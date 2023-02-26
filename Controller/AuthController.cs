using BugTracking.Services;
using BugTracking.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BugTracking.Controller
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

        //User Login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            return Ok(await _authService.Login(viewModel));
        }
        //User Registration
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserCreateViewModel viewModel)
        {
            await _authService.Register(viewModel);
            return Ok();
        }
    }
}
