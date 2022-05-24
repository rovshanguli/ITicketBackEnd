using DomainLayer.Entities;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
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

        public EmailService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task Register(RegisterDto registerDto)
        {

            AppUser appUser = await _userManager.FindByEmailAsync(registerDto.Email);


            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("ITicket", "code.test.iticket@gmail.com"));

            message.To.Add(new MailboxAddress(appUser.Name, appUser.Email));
            message.Subject = "Confirm Email";

            string emailbody = "dsadasd";

            emailbody = emailbody.Replace("{{fullname}}", $"{appUser.Name}").Replace("{{code}}", $"as");

            message.Body = new TextPart(TextFormat.Html) { Text = emailbody };

            using var smtp = new SmtpClient();

            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("code.test.iticket@gmail.com", "Asger54321");
            smtp.Send(message);


            smtp.Disconnect(true);




        }
    }
}
