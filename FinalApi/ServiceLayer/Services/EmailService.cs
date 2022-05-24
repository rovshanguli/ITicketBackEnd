using DomainLayer.Entities;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using MimeKit;
using MimeKit.Text;
using ServiceLayer.DTOs.AppUser;
using ServiceLayer.Services.Interfaces;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class EmailService : IEmailService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _accessor;
        private readonly LinkGenerator _generator;

        public EmailService(UserManager<AppUser> userManager,IWebHostEnvironment env,LinkGenerator generator,IHttpContextAccessor accessor)
        {
            _userManager = userManager;
            _generator = generator;
            _accessor = accessor;
            _env = env;

        }


        public async Task Register(RegisterDto registerDto)
        {

            AppUser appUser = await _userManager.FindByEmailAsync(registerDto.Email);
            var link = GenerateConfirmEmailLink(appUser);
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("ITicket", "code.test.iticket@gmail.com"));
            message.To.Add(new MailboxAddress(appUser.Name, appUser.Email));
            message.Subject = "Confirm Email";
            string emailbody = link.Result;
            message.Body = new TextPart() { Text = emailbody };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("code.test.iticket@gmail.com", "Asger54321");
            smtp.Send(message);
            smtp.Disconnect(true);
        }


        private async Task<string> GenerateConfirmEmailLink(AppUser appUser)
        {
            
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            var callbackLink = _generator.GetUriByPage(_accessor.HttpContext,
                page: "/Account/ConfirmEmail",
                handler: code,
                values: new { area = "Identity", userId = appUser.Id, code = code });

            return callbackLink;
        }
        
        public async Task ConfirmEmail(string userId, string token)
        {
            
            AppUser user = await _userManager.FindByIdAsync(userId);

            await _userManager.ConfirmEmailAsync(user, token);
        }
    }
}
