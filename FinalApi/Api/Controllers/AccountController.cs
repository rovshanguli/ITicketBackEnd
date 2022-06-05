using DomainLayer.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;
        public AccountController(IAccountService service, IWebHostEnvironment env, UserManager<AppUser> userManager, IEmailService emailService)
        {
            _service = service;
            _env = env;
            _userManager = userManager;
            _emailService = emailService;

        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            await _service.Register(registerDto);
            AppUser appUser = await _userManager.FindByEmailAsync(registerDto.Email);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            var link = Url.Action(nameof(ConfirmEmail), "Account", new { userId = appUser.Id, token = code }, Request.Scheme, Request.Host.ToString());
            _emailService.Register(registerDto, link);
            return Ok();
        }

        [HttpGet]
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
