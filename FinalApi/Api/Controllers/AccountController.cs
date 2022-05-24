using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.AppUser;
using ServiceLayer.Services.Interfaces;
using System.Threading.Tasks;


namespace Api.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _service;
        private readonly IWebHostEnvironment _env;
        public AccountController(IAccountService service, IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            await _service.Regsiter(registerDto);
            return Ok();
        }

        [HttpPost]
        [Route("ConfirmEmail")]
        public async Task ConfirmEmail(string userId, string token)
        {
            await _service.ConfirmEmail(userId, token);
        }


        [HttpPost]
        [Route("Login")]
        public async Task<string> Login([FromBody] LoginDto loginDto)
        {
            return await _service.Login(loginDto);
        }
    }
}
