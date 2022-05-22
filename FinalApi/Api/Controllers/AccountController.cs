using DomainLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.AppUser;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Api.Controllers
{
    public class AccountController : BaseController
    {

        private readonly UserManager<AppUser> _userManager;
        
        private readonly ITokenService _tokenService;
        public AccountController(UserManager<AppUser> userManager,
                                 
                                 ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            AppUser user = new()
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                Surname = registerDto.Surname,
                PhoneNumber = registerDto.Mobile,
                UserName = registerDto.UserName
            };

            await _userManager.CreateAsync(user, registerDto.Password);
            await _userManager.AddToRoleAsync(user, "SuperAdmin");
            return Ok();
        }

        


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user is null) return NotFound();

            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password)) return Unauthorized();

            var roles = await _userManager.GetRolesAsync(user);

            string token = _tokenService.GenerateJwtToken(user.UserName, (List<string>)roles);

            return Ok(token);
        }
    }
}
